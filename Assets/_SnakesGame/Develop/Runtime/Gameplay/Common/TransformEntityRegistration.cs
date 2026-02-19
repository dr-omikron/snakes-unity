using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Mono;

namespace _SnakesGame.Develop.Runtime.Gameplay.Common
{
    public class TransformEntityRegistration : MonoEntityRegistrator
    {
        public override void Register(Entity entity) => entity.AddTransform(transform);
    }
}
