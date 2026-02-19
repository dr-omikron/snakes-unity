using _SnakesGame.Develop.Runtime.Utilities.Reactive;

namespace _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore.Snake
{
    public class IsAnyTailExist : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}
