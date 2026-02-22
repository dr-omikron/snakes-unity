using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _SnakesGame.Develop.Runtime.Utilities;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.Sensors
{
    public class ContactsEntitiesFilterSystem : IInitializableSystem, IUpdateableSystem
    {
        private Buffer<Collider> _contacts;
        private Buffer<Entity> _entities;
        private readonly CollidersRegistryService _collidersRegistryService;

        public ContactsEntitiesFilterSystem(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
        }

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _entities = entity.ContactEntitiesBuffer;
        }

        public void OnUpdate(float deltaTime)
        {
            _entities.Count = 0;

            for (int i = 0; i < _contacts.Count; i++)
            {
                Collider collider = _contacts.Items[i];
                Entity entity = _collidersRegistryService.GetBy(collider);

                if (entity != null)
                {
                    _entities.Items[_entities.Count] = entity;
                    _entities.Count++;
                }
            }
        }
    }
}
