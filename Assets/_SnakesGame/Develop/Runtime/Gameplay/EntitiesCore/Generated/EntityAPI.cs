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

	}
}
