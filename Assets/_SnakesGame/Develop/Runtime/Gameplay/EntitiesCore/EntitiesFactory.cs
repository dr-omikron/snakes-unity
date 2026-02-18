using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _SnakesGame.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly MonoEntityFactory _monoEntityFactory;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntityFactory = _container.Resolve<MonoEntityFactory>();
        }

        public Entity CreateSnake(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntityFactory.Create(entity, position, "Entities/SnakeCharacter");

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}
