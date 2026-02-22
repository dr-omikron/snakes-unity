using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Utilities.Conditions;
using _SnakesGame.Develop.Runtime.Utilities.Reactive;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.MovementFeature
{
    public class CanJump : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class HandlingGravity : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class IsGrounded : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class JumpForce : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class GravityForce : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}
