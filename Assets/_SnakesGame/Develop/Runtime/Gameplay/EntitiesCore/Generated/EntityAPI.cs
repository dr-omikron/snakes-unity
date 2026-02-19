namespace _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection MoveDirectionC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public bool TryGetMoveDirection(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveDirection(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.MoveDirection {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed MoveSpeedC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public bool TryGetMoveSpeed(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMoveSpeed(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.MoveSpeed {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove CanMoveC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove>();

		public _SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public bool TryGetCanMove(out _SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMove(_SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection RotationDirectionC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public bool TryGetRotationDirection(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.RotationDirection {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed RotationSpeedC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;

		public bool TryGetRotationSpeed(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.RotationSpeed {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate CanRotateC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate>();

		public _SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanRotate => CanRotateC.Value;

		public bool TryGetCanRotate(out _SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRotate(_SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature.CanRotate {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> CurrentHealth => CurrentHealthC.Value;

		public bool TryGetCurrentHealth(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.CurrentHealth {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> MaxHealth => MaxHealthC.Value;

		public bool TryGetMaxHealth(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Int32> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MaxHealth {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead IsDeadC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public bool TryGetIsDead(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.IsDead {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie MustDieC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie>();

		public _SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustDie => MustDieC.Value;

		public bool TryGetMustDie(out _SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(_SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MustDie {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease MustSelfReleaseC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease>();

		public _SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public bool TryGetMustSelfRelease(out _SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfRelease(_SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.MustSelfRelease {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public bool TryGetDeathProcessInitialTime(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessInitialTime {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public bool TryGetDeathProcessCurrentTime(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.DeathProcessCurrentTime {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess InDeathProcessC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InDeathProcess => InDeathProcessC.Value;

		public bool TryGetInDeathProcess(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeathProcess()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeathProcess(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.LifeCycle.InDeathProcess {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Int32> TakeDamageRequest => TakeDamageRequestC.Value;

		public bool TryGetTakeDamageRequest(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Int32> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Int32>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Int32>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Int32> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageRequest {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent TakeDamageEventC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Int32> TakeDamageEvent => TakeDamageEventC.Value;

		public bool TryGetTakeDamageEvent(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Int32> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Int32>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Int32>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Int32> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.TakeDamageEvent {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage CanApplyDamageC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage>();

		public _SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanApplyDamage => CanApplyDamageC.Value;

		public bool TryGetCanApplyDamage(out _SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanApplyDamage(_SnakesGame.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Features.ApplyDamage.CanApplyDamage {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Snake.IsAnyTailExist IsAnyTailExistC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Snake.IsAnyTailExist>();

		public _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsAnyTailExist => IsAnyTailExistC.Value;

		public bool TryGetIsAnyTailExist(out _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Snake.IsAnyTailExist component);
			if(result)
				value = component.Value;
			else
				value = default(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsAnyTailExist()
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Snake.IsAnyTailExist { Value = new _SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsAnyTailExist(_SnakesGame.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Snake.IsAnyTailExist {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public bool TryGetRigidbody(out UnityEngine.Rigidbody value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Common.RigidbodyComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Rigidbody);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Common.RigidbodyComponent {Value = value});
		}

		public _SnakesGame.Develop.Runtime.Gameplay.Common.TransformComponent TransformC => GetComponent<_SnakesGame.Develop.Runtime.Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public bool TryGetTransform(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out _SnakesGame.Develop.Runtime.Gameplay.Common.TransformComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new _SnakesGame.Develop.Runtime.Gameplay.Common.TransformComponent {Value = value});
		}

	}
}
