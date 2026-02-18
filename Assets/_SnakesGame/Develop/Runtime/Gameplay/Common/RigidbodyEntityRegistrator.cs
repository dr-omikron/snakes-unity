using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Common
{
    public class RigidbodyEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddRigidbody(GetComponent<Rigidbody>());
        }
    }
}
