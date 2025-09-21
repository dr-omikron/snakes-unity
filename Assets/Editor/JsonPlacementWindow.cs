// Assets/Editor/JsonPlacementWindow.cs
// Раскладка префабов из JSON в Edit Mode с корректной конверсией из Unreal → Unity.
// Формат JSON на верхнем уровне — словарь:
// { "<Key>": { "objectName": "...", "objectPosition": {x,y?,z}, "objectRotation": {pitch?,yaw?,roll?} }, ... }

#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools.JsonPlacement
{
    public class JsonPlacementWindow : EditorWindow
    {
        [Header("Источник данных")]
        [SerializeField] private TextAsset jsonFile;
        [SerializeField] private float positionScale = 1f;

        [Header("Поиск префабов")]
        [Tooltip("Папки, в которых искать префабы. По умолчанию: Assets")]
        [SerializeField] private string[] searchInFolders = new[] { "Assets" };

        [Header("Нормализация имён (BP_, суффиксы и т.д.)")]
        [SerializeField] private bool stripBpPrefix = true;
        [SerializeField] private bool stripTrailingNumbers = true;
        [SerializeField] private bool stripHexSuffix = true; // _A1B2C3D4
        [SerializeField] private bool tryBaseBeforeFirstUnderscore = true;
        [SerializeField] private bool useHeuristicBestPrefix = true;

        [Header("Система координат исходных данных")]
        [Tooltip("Отметь, если JSON пришёл из Unreal Engine (X forward, Y right, Z up).")]
        [SerializeField] private bool sourceIsUnreal = true; // ГЛАВНЫЙ ФЛАГ КОНВЕРСИИ

        [Header("Настройки раскладки")]
        [SerializeField] private bool createParentContainer = true;
        [SerializeField] private string parentName = "[PLACED_FROM_JSON]";
        [SerializeField] private bool clearExistingParent = false;

        [Header("Логи")]
        [SerializeField] private bool logDetails = true;
        [SerializeField] private bool logMissing = true;

        private Vector2 _scroll;

        [MenuItem("Tools/Placement/Place Objects From JSON")]
        public static void ShowWindow()
        {
            var wnd = GetWindow<JsonPlacementWindow>("Place From JSON");
            wnd.minSize = new Vector2(560, 540);
        }

        private void OnGUI()
        {
            _scroll = EditorGUILayout.BeginScrollView(_scroll);

            EditorGUILayout.Space(6);
            EditorGUILayout.LabelField("Раскладка объектов из JSON (Edit Mode)", EditorStyles.boldLabel);

            EditorGUILayout.Space(4);
            jsonFile = (TextAsset)EditorGUILayout.ObjectField(new GUIContent("JSON файл", "Файл с objectPosition/objectRotation"), jsonFile, typeof(TextAsset), false);
            positionScale = EditorGUILayout.FloatField(new GUIContent("Коэффициент позиций", "Напр. 0.01 если координаты в сантиметрах"), positionScale);

            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Поиск префабов", EditorStyles.boldLabel);
            int newCount = Mathf.Max(1, EditorGUILayout.IntField("Кол-во папок поиска", searchInFolders.Length));
            if (newCount != searchInFolders.Length)
                Array.Resize(ref searchInFolders, newCount);
            for (int i = 0; i < searchInFolders.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                searchInFolders[i] = EditorGUILayout.TextField($"Папка {i + 1}", searchInFolders[i]);
                if (GUILayout.Button("...", GUILayout.Width(28)))
                {
                    var selected = EditorUtility.OpenFolderPanel("Выберите папку (внутри проекта)", Application.dataPath, "");
                    if (!string.IsNullOrEmpty(selected))
                    {
                        string proj = Application.dataPath.Replace("/Assets", "");
                        if (selected.StartsWith(proj))
                        {
                            var rel = "Assets" + selected.Substring(proj.Length);
                            searchInFolders[i] = rel.Replace("\\", "/");
                        }
                        else
                        {
                            EditorUtility.DisplayDialog("Внимание", "Папка должна быть внутри проекта.", "OK");
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Нормализация имён", EditorStyles.boldLabel);
            stripBpPrefix = EditorGUILayout.Toggle(new GUIContent("Убирать префикс BP_"), stripBpPrefix);
            stripTrailingNumbers = EditorGUILayout.Toggle(new GUIContent("Убирать конечные цифры"), stripTrailingNumbers);
            stripHexSuffix = EditorGUILayout.Toggle(new GUIContent("Убирать HEX-хвост (_A1B2C3D4)"), stripHexSuffix);
            tryBaseBeforeFirstUnderscore = EditorGUILayout.Toggle(new GUIContent("Пробовать основу до первого '_'"), tryBaseBeforeFirstUnderscore);
            useHeuristicBestPrefix = EditorGUILayout.Toggle(new GUIContent("Эвристика лучшего префикса"), useHeuristicBestPrefix);

            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Система координат", EditorStyles.boldLabel);
            sourceIsUnreal = EditorGUILayout.Toggle(new GUIContent("Источник — Unreal Engine"), sourceIsUnreal);

            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Настройки раскладки", EditorStyles.boldLabel);
            createParentContainer = EditorGUILayout.Toggle(new GUIContent("Создать контейнер"), createParentContainer);
            using (new EditorGUI.DisabledScope(!createParentContainer))
            {
                parentName = EditorGUILayout.TextField(new GUIContent("Имя контейнера"), parentName);
                clearExistingParent = EditorGUILayout.Toggle(new GUIContent("Очищать контейнер перед раскладкой"), clearExistingParent);
            }

            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Логи", EditorStyles.boldLabel);
            logDetails = EditorGUILayout.Toggle(new GUIContent("Подробный лог"), logDetails);
            logMissing = EditorGUILayout.Toggle(new GUIContent("Логгировать не найденные префабы"), logMissing);

            EditorGUILayout.Space(10);
            using (new EditorGUI.DisabledScope(jsonFile == null))
            {
                if (GUILayout.Button("Разложить объекты по JSON", GUILayout.Height(36)))
                    PlaceFromJson();
            }

            EditorGUILayout.EndScrollView();
        }

        private void PlaceFromJson()
        {
            if (Application.isPlaying)
            {
                EditorUtility.DisplayDialog("Отключите Play Mode", "Инструмент работает только в Edit Mode.", "OK");
                return;
            }
            if (jsonFile == null)
            {
                EditorUtility.DisplayDialog("Нет JSON", "Выберите JSON файл.", "OK");
                return;
            }
            string json = jsonFile.text;
            if (string.IsNullOrWhiteSpace(json))
            {
                EditorUtility.DisplayDialog("Пустой JSON", "Файл JSON пуст.", "OK");
                return;
            }

            try
            {
                // 1) Парсим твой формат (верхний уровень — словарь)
                var items = ParseItemsFromDictionary(json);
                if (items == null || items.Count == 0)
                {
                    EditorUtility.DisplayDialog("Нет данных", "Не удалось извлечь элементы из JSON.", "OK");
                    return;
                }

                // 2) Индекс префабов
                var prefabIndex = BuildPrefabIndex(searchInFolders);

                // 3) Контейнер
                Transform parent = null;
                if (createParentContainer && !string.IsNullOrWhiteSpace(parentName))
                {
                    var existing = GameObject.Find(parentName);
                    if (existing == null)
                    {
                        var go = new GameObject(parentName);
                        Undo.RegisterCreatedObjectUndo(go, "Create parent container");
                        parent = go.transform;
                    }
                    else
                    {
                        parent = existing.transform;
                        if (clearExistingParent)
                        {
                            var toDelete = new List<GameObject>();
                            for (int i = parent.childCount - 1; i >= 0; i--)
                                toDelete.Add(parent.GetChild(i).gameObject);
                            foreach (var ch in toDelete)
                                Undo.DestroyObjectImmediate(ch);
                        }
                    }
                }

                int placed = 0;
                int missing = 0;
                foreach (var it in items)
                {
                    if (!it.Position.HasValue) // без позиции пропускаем
                        continue;

                    string normalized = NormalizeAssetKey(it.SourceName, stripBpPrefix, stripTrailingNumbers, stripHexSuffix);

                    UnityEngine.Object prefab = null;
                    if (!prefabIndex.TryGetValue(normalized, out prefab))
                    {
                        if (tryBaseBeforeFirstUnderscore)
                        {
                            var baseKey = TakeBaseBeforeFirstUnderscore(normalized);
                            if (!string.Equals(baseKey, normalized, StringComparison.OrdinalIgnoreCase))
                                prefabIndex.TryGetValue(baseKey, out prefab);
                        }
                        if (prefab == null && useHeuristicBestPrefix)
                            prefab = HeuristicBestPrefix(prefabIndex, normalized);
                    }

                    if (prefab == null)
                    {
                        missing++;
                        if (logMissing)
                            Debug.LogWarning($"[JsonPlacement] Префаб не найден для '{it.SourceName}' (ключ: '{normalized}').");
                        continue;
                    }

                    var instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                    if (instance == null)
                    {
                        missing++;
                        if (logMissing)
                            Debug.LogWarning($"[JsonPlacement] Не удалось инстанцировать '{prefab.name}' для '{it.SourceName}'.");
                        continue;
                    }

                    Undo.RegisterCreatedObjectUndo(instance, "Place object from JSON");
                    instance.name = it.OriginalKey; // сохраняем точное имя из JSON-ключа

                    if (parent != null)
                        Undo.SetTransformParent(instance.transform, parent, "Parent placed object");

                    // === КОНВЕРСИЯ ИЗ UE → UNITY ===
                    // Позиция:
                    Vector3 posWorld = sourceIsUnreal
                        ? ConvertPositionUEToUnity(it.Position.Value) * positionScale
                        : it.Position.Value * positionScale;

                    // Поворот:
                    Quaternion rotWorld = sourceIsUnreal
                        ? ConvertRotationUEToUnity(it.EulerDegrees ?? Vector3.zero)
                        : Quaternion.Euler(it.EulerDegrees ?? Vector3.zero);

                    instance.transform.position = posWorld;
                    instance.transform.rotation = rotWorld;

                    placed++;
                    if (logDetails)
                        Debug.Log($"[JsonPlacement] Placed '{instance.name}' at {posWorld} rot {(sourceIsUnreal ? (ConvertRotationUEToUnity(it.EulerDegrees ?? Vector3.zero)).eulerAngles : (it.EulerDegrees ?? Vector3.zero))} from '{it.SourceName}'.");
                }

                EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
                EditorUtility.DisplayDialog("Готово", $"Размещено: {placed}\nНе найдено префабов: {missing}", "OK");
                if (logDetails)
                    Debug.Log($"[JsonPlacement] Done. Placed={placed}, Missing={missing}.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"[JsonPlacement] Ошибка: {ex.Message}\n{ex.StackTrace}");
                EditorUtility.DisplayDialog("Ошибка", $"См. Console. {ex.Message}", "OK");
            }
        }

        // ======= КОНВЕРСИЯ UE → UNITY =======

        // Позиция: UE (X forward, Y right, Z up) → Unity (X right, Y up, Z forward)
        // (X,Y,Z)_UE → (Y,Z,X)_Unity
        private static Vector3 ConvertPositionUEToUnity(Vector3 posUE)
        {
            return new Vector3(posUE.y, posUE.z, posUE.x);
        }

        // Поворот: UE Rotator(pitch around UE Y, yaw around UE Z, roll around UE X)
        // Оси UE → Unity:  X→Z, Y→X, Z→Y
        // Порядок UE матрицы: Yaw * Pitch * Roll  (применяется как Roll затем Pitch затем Yaw)
        // Соответственно в Unity:
        // q = RotY(yaw) * RotX(pitch) * RotZ(roll)
        private static Quaternion ConvertRotationUEToUnity(Vector3 pryDegUE)
        {
            float pitch = pryDegUE.x; // UE pitch (вокруг UE Y) → Unity X
            float yaw   = pryDegUE.y; // UE yaw   (вокруг UE Z) → Unity Y
            float roll  = pryDegUE.z; // UE roll  (вокруг UE X) → Unity Z

            Quaternion qYaw   = Quaternion.AngleAxis(yaw,   Vector3.up);
            Quaternion qPitch = Quaternion.AngleAxis(pitch, Vector3.right);
            Quaternion qRoll  = Quaternion.AngleAxis(roll,  Vector3.forward);

            return qYaw * qPitch * qRoll;
        }

        // ======= Парсинг твоего формата (верхний уровень — объект/словарь) =======

        private static List<Item> ParseItemsFromDictionary(string objectJson)
        {
            var pairs = ExtractTopLevelPairs(objectJson);
            var result = new List<Item>(pairs.Count);

            foreach (var p in pairs)
            {
                try
                {
                    var inner = JsonUtility.FromJson<InnerData>(p.valueJson);
                    if (inner == null) continue;

                    string sourceName = !string.IsNullOrWhiteSpace(inner.objectName) ? inner.objectName : p.key;

                    Vector3? pos = null;
                    if (inner.objectPosition != null)
                        pos = inner.objectPosition.ToVector3Safe();

                    Vector3 eulerPRY = Vector3.zero;
                    if (inner.objectRotation != null)
                        eulerPRY = inner.objectRotation.ToEulerVector3(); // pitch->X, yaw->Y, roll->Z

                    var item = new Item
                    {
                        OriginalKey = p.key,
                        SourceName = sourceName,
                        Position = pos,
                        EulerDegrees = inner.objectRotation != null ? (Vector3?)eulerPRY : Vector3.zero
                    };

                    result.Add(item);
                }
                catch (Exception ex)
                {
                    Debug.LogWarning($"[JsonPlacement] Не удалось разобрать элемент '{p.key}': {ex.Message}");
                }
            }

            return result;
        }

        // Разбор верхнего уровня: "ключ": { ...json... }
        private static List<(string key, string valueJson)> ExtractTopLevelPairs(string src)
        {
            var list = new List<(string, string)>();
            if (string.IsNullOrWhiteSpace(src)) return list;

            int i = 0;
            while (i < src.Length && char.IsWhiteSpace(src[i])) i++;
            if (i >= src.Length || src[i] != '{') return list;
            i++;

            while (i < src.Length)
            {
                while (i < src.Length && (char.IsWhiteSpace(src[i]) || src[i] == ',')) i++;
                if (i >= src.Length) break;
                if (src[i] == '}') { i++; break; }

                if (src[i] != '"') break;
                i++;

                var keyBuilder = new System.Text.StringBuilder();
                bool escaped = false;
                while (i < src.Length)
                {
                    char c = src[i];
                    if (!escaped && c == '\\') { escaped = true; i++; continue; }
                    if (!escaped && c == '"') { i++; break; }
                    escaped = false;
                    keyBuilder.Append(c);
                    i++;
                }
                string key = keyBuilder.ToString();

                while (i < src.Length && char.IsWhiteSpace(src[i])) i++;
                if (i >= src.Length || src[i] != ':') break;
                i++;

                while (i < src.Length && char.IsWhiteSpace(src[i])) i++;
                if (i >= src.Length) break;

                if (src[i] != '{') break;
                int objStart = i;
                int depth = 0;
                while (i < src.Length)
                {
                    if (src[i] == '{') depth++;
                    else if (src[i] == '}')
                    {
                        depth--;
                        if (depth == 0) { i++; break; }
                    }
                    i++;
                }
                int objEnd = i;
                if (objEnd > objStart)
                {
                    string valJson = src.Substring(objStart, objEnd - objStart);
                    list.Add((key, valJson));
                }
            }
            return list;
        }

        // ======= Поиск префабов и нормализация =======

        private static Dictionary<string, UnityEngine.Object> BuildPrefabIndex(string[] folders)
        {
            if (folders == null || folders.Length == 0 || folders.All(string.IsNullOrWhiteSpace))
                folders = new[] { "Assets" };

            var guids = AssetDatabase.FindAssets("t:Prefab", folders);
            var index = new Dictionary<string, UnityEngine.Object>(StringComparer.OrdinalIgnoreCase);

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var obj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
                if (obj == null) continue;

                string fileName = Path.GetFileNameWithoutExtension(path);
                string key = NormalizeAssetKey(fileName, true, true, true);

                if (!index.ContainsKey(key))
                    index[key] = obj;
                else
                {
                    if (fileName.Equals(key, StringComparison.OrdinalIgnoreCase))
                        index[key] = obj;
                }
            }
            return index;
        }

        private static string NormalizeAssetKey(string name, bool stripBp, bool stripNums, bool stripHex)
        {
            if (string.IsNullOrWhiteSpace(name)) return string.Empty;
            string s = name.Trim();

            if (stripBp && s.StartsWith("BP_", StringComparison.OrdinalIgnoreCase))
                s = s.Substring(3);

            if (stripHex)
                s = Regex.Replace(s, @"_[0-9A-Fa-f]{8}$", ""); // _A1B2C3D4

            if (stripNums)
                s = Regex.Replace(s, @"[\s_\-]*\d+$", ""); // финальные цифры

            return s;
        }

        private static string TakeBaseBeforeFirstUnderscore(string key)
        {
            int idx = key.IndexOf('_');
            if (idx > 0) return key.Substring(0, idx);
            return key;
        }

        private static UnityEngine.Object HeuristicBestPrefix(Dictionary<string, UnityEngine.Object> index, string normalizedKey)
        {
            UnityEngine.Object best = null;
            int bestLen = 0;

            foreach (var kv in index)
            {
                var k = kv.Key;
                if (normalizedKey.StartsWith(k, StringComparison.OrdinalIgnoreCase))
                {
                    if (k.Length > bestLen)
                    {
                        best = kv.Value;
                        bestLen = k.Length;
                    }
                }
            }

            if (best != null) return best;

            foreach (var kv in index)
            {
                var k = kv.Key;
                if (k.StartsWith(normalizedKey, StringComparison.OrdinalIgnoreCase))
                {
                    if (normalizedKey.Length > bestLen)
                    {
                        best = kv.Value;
                        bestLen = normalizedKey.Length;
                    }
                }
            }
            return best;
        }

        // ======= DTO =======

        [Serializable]
        private class InnerData
        {
            public string objectName;
            public Vec3Maybe objectPosition;
            public RotPRY objectRotation;
        }

        [Serializable]
        private class Vec3Maybe
        {
            public float x;
            public float y; // может отсутствовать в JSON -> 0
            public float z;

            public Vector3 ToVector3Safe() => new Vector3(x, y, z);
        }

        [Serializable]
        private class RotPRY
        {
            public float pitch; // UE: вокруг Y
            public float yaw;   // UE: вокруг Z
            public float roll;  // UE: вокруг X

            public Vector3 ToEulerVector3() => new Vector3(pitch, yaw, roll);
        }

        private class Item
        {
            public string OriginalKey;
            public string SourceName;
            public Vector3? Position;      // world pos (UE или Unity в зависимости от sourceIsUnreal)
            public Vector3? EulerDegrees;  // UE PRY в градусах (если sourceIsUnreal=true) или Unity euler
        }
    }
}
#endif
