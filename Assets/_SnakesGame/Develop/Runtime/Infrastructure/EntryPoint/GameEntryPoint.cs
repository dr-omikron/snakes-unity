using System.Collections;
using _SnakesGame.Develop.Runtime.Gameplay.Infrastructure;
using _SnakesGame.Develop.Runtime.Infrastructure.DI;
using _SnakesGame.Develop.Runtime.Utilities.ConfigsManagement;
using _SnakesGame.Develop.Runtime.Utilities.CoroutinesManagement;
using _SnakesGame.Develop.Runtime.Utilities.LoadingScreen;
using _SnakesGame.Develop.Runtime.Utilities.SceneManagement;
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

            SetupWindowsAppSetting();

#endif

            DIContainer container = new DIContainer();
            ProjectContextRegistrations.Process(container);
            container.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(container));
        }

        private void SetupAndroidAppSetting()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private void SetupWindowsAppSetting()
        {
            //windows app settings
        }

        private IEnumerator Initialize(DIContainer container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();

            loadingScreen.Show();

            yield return container.Resolve<ConfigsProviderService>().LoadAsync();

            loadingScreen.Hide();

            yield return sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(1));
        }
    }
}
