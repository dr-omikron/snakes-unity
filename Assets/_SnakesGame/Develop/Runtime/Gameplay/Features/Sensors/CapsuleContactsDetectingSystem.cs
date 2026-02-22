using System;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _SnakesGame.Develop.Runtime.Utilities;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.Sensors
{
    public class CapsuleContactsDetectingSystem : IInitializableSystem, IUpdateableSystem
    {
        private Buffer<Collider> _contacts;
        private LayerMask _layerMask;
        private CapsuleCollider _collider;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _layerMask = entity.ContactDetectingMask;
            
            if(entity.BodyCollider is CapsuleCollider body == false)
                throw new ArgumentException("Body Collider is not capsule collider");

            _collider = body;
        }

        public void OnUpdate(float deltaTime)
        {
            _contacts.Count = Physics.OverlapCapsuleNonAlloc(
                _collider.bounds.min,
                _collider.bounds.max,
                _collider.radius,
                _contacts.Items,
                _layerMask.value,
                QueryTriggerInteraction.Collide);

            Debug.Log($"Capsule found {_contacts.Count}");

            if (_contacts.Count > 0)
            {
                Debug.Log("Detected object layer: " + LayerMask.LayerToName(_contacts.Items[0].gameObject.layer));
                Debug.Log("Detected object name: " + _contacts.Items[0].name);
            }
        }
    }
}
