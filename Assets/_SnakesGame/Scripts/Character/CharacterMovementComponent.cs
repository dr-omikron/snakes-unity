using UnityEngine;

namespace _SnakesGame.Scripts.Character
{
    [RequireComponent(typeof(Rigidbody))]

    public class CharacterMovementComponent : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;
        private Rigidbody _characterRigidbody;

        void Start()
        {
            _characterRigidbody = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 moveDirection)
        {
            if (_characterRigidbody.linearVelocity.magnitude > _maxSpeed)
                _characterRigidbody.AddForce(moveDirection * _maxSpeed);
            else
                _characterRigidbody.AddForce(moveDirection * _acceleration, ForceMode.Acceleration);
        }
    }
}
