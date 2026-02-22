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
        public bool JumpButtonPressed { get; private set; }

        private SnakesInputs _snakesInputs;

        public void Initialize()
        {
            _snakesInputs = new SnakesInputs();
            InputSystem.onBeforeUpdate += OnBeforeUpdate;

            _snakesInputs.Player.Move.performed += OnMoveInputReceived;
            _snakesInputs.Player.Move.canceled += OnMoveInputCanceled;
            _snakesInputs.Player.Attack.started += OnAttackPressed;
            _snakesInputs.Player.Attack.canceled += OnAttackReleased;
            _snakesInputs.Player.Jump.started += OnJumpStarted;
            _snakesInputs.Player.Jump.canceled += OnJumpReleased;

            EnableInputs();
        }

        public void EnableInputs() => _snakesInputs.Enable();

        public void DisableInputs() => _snakesInputs.Disable();

        public void Dispose()
        {
            InputSystem.onBeforeUpdate -= OnBeforeUpdate;

            _snakesInputs.Player.Move.performed -= OnMoveInputReceived;
            _snakesInputs.Player.Move.canceled -= OnMoveInputCanceled;
            _snakesInputs.Player.Attack.started -= OnAttackPressed;
            _snakesInputs.Player.Attack.canceled -= OnAttackReleased;
            _snakesInputs.Player.Jump.started -= OnJumpStarted;
            _snakesInputs.Player.Jump.canceled -= OnJumpReleased;
        }

        private void OnMoveInputReceived(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            InputDirection = new Vector3(input.x, 0, input.y);
        }

        private void OnMoveInputCanceled(InputAction.CallbackContext context)
            => InputDirection = Vector3.zero;

        private void OnJumpStarted(InputAction.CallbackContext context)
        {
            JumpButtonPressed = true;
            JumpPressed?.Invoke();
        }

        private void OnJumpReleased(InputAction.CallbackContext context)
        {
            JumpButtonPressed = false;
            JumpReleased?.Invoke();
        }

        private void OnBeforeUpdate()
        {
            JumpButtonPressed = false;
        }

        private void OnAttackPressed(InputAction.CallbackContext context) 
            => AttackPressed?.Invoke();

        private void OnAttackReleased(InputAction.CallbackContext context) 
            => AttackReleased?.Invoke();
    }
}
