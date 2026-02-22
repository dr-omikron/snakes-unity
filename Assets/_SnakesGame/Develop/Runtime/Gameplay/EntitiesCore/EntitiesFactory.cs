using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage;
using _SnakesGame.Develop.Runtime.Gameplay.Features.ContactTakeDamage;
using _SnakesGame.Develop.Runtime.Gameplay.Features.InputFeatures;
using _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle;
using _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature;
using _SnakesGame.Develop.Runtime.Gameplay.Features.Sensors;
using _SnakesGame.Develop.Runtime.Infrastructure.DI;
using _SnakesGame.Develop.Runtime.Utilities;
using _SnakesGame.Develop.Runtime.Utilities.Conditions;
using _SnakesGame.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly CollidersRegistryService _collidersRegistryService;
        private readonly MonoEntityFactory _monoEntityFactory;
        private readonly GameplayInputService _gameplayInputService;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _collidersRegistryService = _container.Resolve<CollidersRegistryService>();
            _monoEntityFactory = _container.Resolve<MonoEntityFactory>();
            _gameplayInputService = _container.Resolve<GameplayInputService>();
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
                .AddJumpForce(new ReactiveVariable<float>(10))
                .AddGravityForce(new ReactiveVariable<float>(50.0f))
                .AddIsGrounded()
                .AddGroundCheckMask(LayerMask.GetMask("RegularFloor") | LayerMask.GetMask("Ice"))
                .AddCurrentHealth(new ReactiveVariable<int>(1))
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(2))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddContactDetectingMask(LayerMask.GetMask("Enemy"))
                .AddContactCollidersBuffer(new Buffer<Collider>(32))
                .AddContactEntitiesBuffer(new Buffer<Entity>(32));

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canJump = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.IsGrounded.Value))
                .Add(new FuncCondition(() => _gameplayInputService.JumpButtonPressed));

            ICompositeCondition handlingGravity = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.IsGrounded.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));
                //.Add(new FuncCondition(() => entity.IsAnyTailExist.Value == false));

            entity.AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddCanJump(canJump)
                .AddHandlingGravity(handlingGravity)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new SphereGroundDetectingSystem())
                .AddSystem(new RigidbodyJumpSystem())
                .AddSystem(new RigidbodyGravitySystem())
                .AddSystem(new CapsuleContactsDetectingSystem())
                .AddSystem(new ContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

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
                .AddCurrentHealth(new ReactiveVariable<int>(1))
                .AddIsDead()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddContactDetectingMask(LayerMask.GetMask("Snake"))
                .AddContactCollidersBuffer(new Buffer<Collider>(32))
                .AddContactEntitiesBuffer(new Buffer<Entity>(32))
                .AddContactDamage(new ReactiveVariable<int>(1));

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddCanMove(canMove)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage);

            entity
                .AddSystem(new TransformMovementSystem())
                .AddSystem(new BoxContactsDetectingSystem())
                .AddSystem(new ContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new SelfReleaseSystem(_container.Resolve<EntitiesLifeContext>()));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}
