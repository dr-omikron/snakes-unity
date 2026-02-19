using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle;
using _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature;
using _SnakesGame.Develop.Runtime.Infrastructure.DI;
using _SnakesGame.Develop.Runtime.Utilities.Reactive;
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

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(999))
                .AddCurrentHealth(new ReactiveVariable<int>(1))
                .AddIsDead();

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new SelfReleaseSystem(_container.Resolve<EntitiesLifeContext>()));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateChecker(Vector3 position)
        {
            Entity entity = CreateEmpty();
            _monoEntityFactory.Create(entity, position, "Entities/Checker");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddCurrentHealth(new ReactiveVariable<int>(3))
                .AddIsDead();

            entity
                .AddSystem(new TransformMovementSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new SelfReleaseSystem(_container.Resolve<EntitiesLifeContext>()));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}
