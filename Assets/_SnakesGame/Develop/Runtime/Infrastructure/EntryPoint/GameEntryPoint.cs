using System.Collections;
using _SnakesGame.Develop.Runtime.Infrastructure.DI;
using _SnakesGame.Develop.Runtime.Utilities.ConfigsManagement;
using _SnakesGame.Develop.Runtime.Utilities.CoroutinesManagement;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Infrastructure.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
#if PLATFORM_STANDALONE_ANDROID

            SetupAndroidSetting();

#elif PLATFORM_STANDALONE_WIN

            SetupWindowsSetting();

#endif

            DIContainer container = new DIContainer();
            ProjectContextRegistrations.Process(container);
            container.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(container));
        }

        private void SetupAndroidSetting()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private void SetupWindowsSetting()
        {
            //windows settings
        }

        private IEnumerator Initialize(DIContainer container)
        {
            yield return container.Resolve<ConfigsProviderService>().LoadAsync();
        }
    }
}
