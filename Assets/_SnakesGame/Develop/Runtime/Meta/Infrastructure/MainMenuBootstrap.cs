using System.Collections;
using _SnakesGame.Develop.Runtime.Gameplay.Infrastructure;
using _SnakesGame.Develop.Runtime.Infrastructure;
using _SnakesGame.Develop.Runtime.Infrastructure.DI;
using _SnakesGame.Develop.Runtime.Utilities.CoroutinesManagement;
using _SnakesGame.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private ICoroutinesPerformer _coroutinesPerformer;

        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;
            MainMenuContextRegistrations.Process(container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("MainMenu Scene Initialized");
            yield break;
        }

        public override void Run()
        {
            Debug.Log("MainMenu Scene Started");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(1)));
            }
        }
    }
}
