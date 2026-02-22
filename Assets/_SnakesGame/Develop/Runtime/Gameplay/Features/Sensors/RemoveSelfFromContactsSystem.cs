using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _SnakesGame.Develop.Runtime.Utilities;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.Sensors
{
    public class RemoveSelfFromContactsSystem : IInitializableSystem, IUpdateableSystem
    {
        private Buffer<Collider> _contacts;
        private Collider _collider;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _collider = entity.BodyCollider;
        }

        public void OnUpdate(float deltaTime)
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.Items[i] == _collider)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _contacts.Count - 1; i++)
                {
                    _contacts.Items[i] = _contacts.Items[i + 1];
                }

                _contacts.Count--;
            }
        }
    }
}
