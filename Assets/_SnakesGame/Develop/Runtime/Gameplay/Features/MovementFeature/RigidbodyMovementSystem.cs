using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _SnakesGame.Develop.Runtime.Utilities.Conditions;
using _SnakesGame.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RigidbodyMovementSystem : IInitializableSystem, IUpdateableSystem
    {
        private ReactiveVariable<Vector3> _moveDirection;
        private ReactiveVariable<float> _moveSpeed;
        private Rigidbody _rigidbody;

        private ICompositeCondition _canMove;

        public void OnInit(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _moveSpeed = entity.MoveSpeed;
            _rigidbody = entity.Rigidbody;
            _canMove = entity.CanMove;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canMove.Evaluate() == false)
            {
                _rigidbody.linearVelocity = new Vector3(0, _rigidbody.linearVelocity.y, 0);
                return;
            }

            Vector3 groundVelocity = _moveDirection.Value.normalized * _moveSpeed.Value;
            Vector3 velocity = new Vector3(groundVelocity.x, _rigidbody.linearVelocity.y, groundVelocity.z);
            _rigidbody.linearVelocity = velocity;
        }
    }
}
