using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _SnakesGame.Develop.Runtime.Utilities.Conditions;
using _SnakesGame.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RigidbodyJumpSystem : IInitializableSystem, IUpdateableSystem
    {
        private ReactiveVariable<float> _jumpForce;
        private Rigidbody _rigidbody;

        private ICompositeCondition _canJump;

        public void OnInit(Entity entity)
        {
            _jumpForce = entity.JumpForce;
            _rigidbody = entity.Rigidbody;
            _canJump = entity.CanJump;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_canJump.Evaluate())
            {
                _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, _rigidbody.linearVelocity.y + _jumpForce.Value,
                    _rigidbody.linearVelocity.z);
                
                Debug.Log("Jump force: " + _rigidbody.linearVelocity);
            };
        }
    }
}
