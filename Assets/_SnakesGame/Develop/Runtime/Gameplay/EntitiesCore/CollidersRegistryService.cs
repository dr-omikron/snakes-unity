using System.Collections.Generic;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore
{
    public class CollidersRegistryService
    {
        private readonly Dictionary<Collider, Entity> _entities = new Dictionary<Collider, Entity>();

        public void Register(Collider collider, Entity entity) => _entities.Add(collider, entity);

        public void Unregister(Collider collider) => _entities.Remove(collider);

        public Entity GetBy(Collider collider) => _entities.GetValueOrDefault(collider);
    }
}
