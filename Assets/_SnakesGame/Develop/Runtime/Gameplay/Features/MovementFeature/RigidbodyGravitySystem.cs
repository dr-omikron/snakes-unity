using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _SnakesGame.Develop.Runtime.Utilities.Conditions;
using _SnakesGame.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class RigidbodyGravitySystem : IInitializableSystem, IUpdateableSystem
    {
        private ReactiveVariable<float> _gravityForce;
        private Rigidbody _rigidbody;

        private ICompositeCondition _handlingGravity;

        public void OnInit(Entity entity)
        {
            _gravityForce = entity.GravityForce;
            _rigidbody = entity.Rigidbody;
            _handlingGravity = entity.HandlingGravity;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_handlingGravity.Evaluate())
            {
                _rigidbody.linearVelocity = new Vector3(
                    _rigidbody.linearVelocity.x,
                    _rigidbody.linearVelocity.y - _gravityForce.Value * deltaTime,
                    _rigidbody.linearVelocity.z);
                
                Debug.Log(_rigidbody.linearVelocity);
            }
        }
    }
}
