using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Common
{
    public class GroundCheckColliderRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Collider _groundCheckCollider;
        public override void Register(Entity entity)
        {
            entity.AddGroundCheckCollider(_groundCheckCollider);
        }
    }
}
