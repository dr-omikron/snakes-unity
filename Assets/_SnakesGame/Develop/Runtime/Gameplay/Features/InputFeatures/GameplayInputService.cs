using System;
using _Archero.Develop.Runtime.Infrastructure.DI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _SnakesGame.Develop.Runtime.Gameplay.Features.InputFeatures
{
    public class GameplayInputService : IInitializable, IDisposable
    {
        public event Action AttackPressed;
        public event Action AttackReleased;
        public event Action JumpPressed;
        public event Action JumpReleased;

        public Vector3 InputDirection { get; private set; }

        private SnakesInputs _snakesInputs;

        public void Initialize()
        {
            _snakesInputs = new SnakesInputs();

            _snakesInputs.Player.Move.performed += OnMoveInputReceived;
            _snakesInputs.Player.Move.canceled += OnMoveInputCanceled;
            _snakesInputs.Player.Attack.started += OnAttackPressed;
            _snakesInputs.Player.Attack.canceled += OnAttackReleased;
            _snakesInputs.Player.Jump.performed += OnJumpPressed;
            _snakesInputs.Player.Jump.canceled += OnJumpReleased;

            EnableInputs();
        }

        public void EnableInputs() => _snakesInputs.Enable();

        public void DisableInputs() => _snakesInputs.Disable();

        public void Dispose()
        {
            _snakesInputs.Player.Move.performed -= OnMoveInputReceived;
            _snakesInputs.Player.Move.canceled -= OnMoveInputCanceled;
            _snakesInputs.Player.Attack.started -= OnAttackPressed;
            _snakesInputs.Player.Attack.canceled -= OnAttackReleased;
            _snakesInputs.Player.Jump.performed -= OnJumpPressed;
            _snakesInputs.Player.Jump.canceled -= OnJumpReleased;
        }

        private void OnMoveInputReceived(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            InputDirection = new Vector3(input.x, 0, input.y);
        }

        private void OnMoveInputCanceled(InputAction.CallbackContext context)
            => InputDirection = Vector3.zero;

        private void OnJumpPressed(InputAction.CallbackContext context) 
            => JumpPressed?.Invoke();

        private void OnJumpReleased(InputAction.CallbackContext context)
            => JumpReleased?.Invoke();

        private void OnAttackPressed(InputAction.CallbackContext context) 
            => AttackPressed?.Invoke();

        private void OnAttackReleased(InputAction.CallbackContext context) 
            => AttackReleased?.Invoke();
    }
}
