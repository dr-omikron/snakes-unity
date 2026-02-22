using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Common
{
    public class BodyColliderRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Collider _body;
        public override void Register(Entity entity)
        {
            entity.AddBodyCollider(_body);
        }
    }
}
