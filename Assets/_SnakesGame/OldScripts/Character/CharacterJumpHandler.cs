using System;
using UnityEngine;

namespace _SnakesGame.Scripts.Character
{
    [RequireComponent(typeof(Rigidbody))]

    public class CharacterJumpHandler : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _checkSphereRadius;
        [SerializeField] private Transform _floorPoint;
        [SerializeField] private LayerMask _floorLayer;

        private Rigidbody _characterRigidbody;
        private bool _isGrounded;

        private void Start()
        {
            _characterRigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            GroundCheck();
        }

        public void HandleJump()
        {
            if(_isGrounded)
                _characterRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        private void GroundCheck() => _isGrounded = Physics.CheckSphere(_floorPoint.position, _checkSphereRadius, _floorLayer);
        public bool IsGrounded() => _isGrounded;
        public bool IsFalling() => _characterRigidbody.linearVelocity.y < -0.001f;
        public bool IsJumping() => _characterRigidbody.linearVelocity.y > 0.001f;
    }
}
