using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Mono
{
    public class MonoEntity : MonoBehaviour
    {
        private Entity _linkedEntity;

        public Entity LinkedEntity => _linkedEntity;
        public void Link(Entity entity)
        {
            _linkedEntity = entity;

            MonoEntityRegistrator[] registrators = GetComponentsInChildren<MonoEntityRegistrator>();

            if (registrators != null)
                foreach (MonoEntityRegistrator registrator in registrators)
                    registrator.Register(entity);

        }

        public void Cleanup(Entity entity)
        {
        }
    }
}
