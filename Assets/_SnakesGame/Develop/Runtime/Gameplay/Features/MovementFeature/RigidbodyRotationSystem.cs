using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _SnakesGame.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RigidbodyRotationSystem : IInitializableSystem, IUpdateableSystem
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<float> _rotationSpeed;
        private Rigidbody _rigidbody;

        public void OnInit(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _rotationSpeed = entity.RotationSpeed;
            _rigidbody = entity.Rigidbody;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_rotationDirection.Value == Vector3.zero)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(_rotationDirection.Value.normalized);
            float step = _rotationSpeed.Value * deltaTime;
            Quaternion rotation = Quaternion.RotateTowards(_rigidbody.rotation, lookRotation, step);
            _rigidbody.MoveRotation(rotation);
        }
    }
}
