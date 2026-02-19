using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.Features.InputFeatures;
using _SnakesGame.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay
{
    public class TestGameplay : MonoBehaviour
    {
        private DIContainer _container;
        private EntitiesFactory _entitiesFactory;
        private GameplayInputService _gameplayInputService;
        private Entity _snake;
        private Entity _checker;
        
        private bool _isRunning;

        public void Initialize(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _gameplayInputService = _container.Resolve<GameplayInputService>();
        }

        public void Run()
        {
            _snake = _entitiesFactory.CreateSnake(Vector3.zero);
            _checker = _entitiesFactory.CreateChecker(Vector3.zero + Vector3.forward * 2);
            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            _snake.MoveDirection.Value = _gameplayInputService.InputDirection;
            _snake.RotationDirection.Value = _gameplayInputService.InputDirection;

            if (Input.GetKeyDown(KeyCode.C))
            {
                _checker.CurrentHealth.Value--;
                Debug.Log("Checker Health: " + _checker.CurrentHealth.Value);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _snake.CurrentHealth.Value--;
                Debug.Log("Snake Health: " + _snake.CurrentHealth.Value);
            }
        }
    }
}
