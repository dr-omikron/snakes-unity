using _SnakesGame.Develop.Runtime.Gameplay.EntitiesCore;
using _SnakesGame.Develop.Runtime.Utilities;
using UnityEngine;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.Sensors
{
    public class BodyCollider : IEntityComponent
    {
        public Collider Value;
    }

    public class ContactDetectingMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class ContactCollidersBuffer : IEntityComponent
    {
        public Buffer<Collider> Value;
    }

    public class ContactEntitiesBuffer : IEntityComponent
    {
        public Buffer<Entity> Value;
    }

    public class GroundCheckCollider : IEntityComponent
    {
        public Collider Value;
    }

    public class GroundCheckMask : IEntityComponent
    {
        public LayerMask Value;
    }
}
