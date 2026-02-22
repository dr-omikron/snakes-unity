using System;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _SnakesGame.Develop.Runtime.Utilities;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.Sensors
{
    public class BoxContactsDetectingSystem : IInitializableSystem, IUpdateableSystem
    {
        private Buffer<Collider> _contacts;
        private LayerMask _layerMask;
        private BoxCollider _collider;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _layerMask = entity.ContactDetectingMask;
            
            if(entity.BodyCollider is BoxCollider body == false)
                throw new ArgumentException("Body Collider is not box collider");

            _collider = body;
        }

        public void OnUpdate(float deltaTime)
        {
            _contacts.Count = Physics.OverlapBoxNonAlloc(
                _collider.bounds.center,
                _collider.bounds.size * 0.5f,
                _contacts.Items,
                Quaternion.identity,
                _layerMask.value,
                QueryTriggerInteraction.Ignore);


            Debug.Log($"Box found {_contacts.Count}");

            if (_contacts.Count > 0)
            {
                Debug.Log("Detected object layer: " + LayerMask.LayerToName(_contacts.Items[0].gameObject.layer));
                Debug.Log("Detected object name: " + _contacts.Items[0].name);
            }
        }
    }
}
