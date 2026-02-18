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
            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            _snake.MoveDirection.Value = _gameplayInputService.InputDirection;
        }
    }
}
