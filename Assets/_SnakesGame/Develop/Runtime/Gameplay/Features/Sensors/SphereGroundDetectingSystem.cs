using System;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _SnakesGame.Develop.Runtime.Utilities;
using _SnakesGame.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.Sensors
{
    public class SphereGroundDetectingSystem : IInitializableSystem, IUpdateableSystem
    {
        private LayerMask _layerMask;
        private SphereCollider _collider;
        private ReactiveVariable<bool> _isGrounded;

        private readonly Buffer<Collider> _contacts = new Buffer<Collider>(1);

        public void OnInit(Entity entity)
        {
            _layerMask = entity.GroundCheckMask;
            _isGrounded = entity.IsGrounded;

            if(entity.GroundCheckCollider is SphereCollider collider == false)
                throw new ArgumentException("Ground checker collider is not sphere collider");

            _collider = collider;
        }

        public void OnUpdate(float deltaTime)
        {
            _contacts.Count = Physics.OverlapSphereNonAlloc(
                _collider.transform.position,
                _collider.radius,
                _contacts.Items,
                _layerMask.value,
                QueryTriggerInteraction.Ignore);

            _isGrounded.Value = _contacts.Count > 0;

            Debug.Log(_isGrounded.Value ? "Grounded" : "Not grounded");
        }
    }
}
