using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Utilities.Reactive;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.ContactTakeDamage
{
    public class ContactDamage : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }
}
