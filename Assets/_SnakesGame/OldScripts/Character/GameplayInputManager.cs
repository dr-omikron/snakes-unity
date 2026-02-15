using System;
using UnityEngine;

namespace _SnakesGame.Scripts.Character
{
    public class GameplayInputManager : MonoBehaviour
    {
        public event Action<Vector2> OnMoveInputReceived;
        public event Action OnMoveInputCancelled;

        public event Action OnAttackPressed;
        public event Action OnAttackReleased;

        public event Action OnJumpPressed;
        public event Action OnJumpReleased;

        private SnakesInputs _snakesInputs;

        private void Awake()
        {
            _snakesInputs = new SnakesInputs();
        }

        private void Start()
        {
            _snakesInputs.Player.Move.performed += context => OnMoveInputReceived?.Invoke(context.ReadValue<Vector2>());
            _snakesInputs.Player.Move.canceled += _ => OnMoveInputCancelled?.Invoke();
            _snakesInputs.Player.Attack.started += _ => OnAttackPressed?.Invoke();
            _snakesInputs.Player.Attack.canceled +=  _ => OnAttackReleased?.Invoke();
            _snakesInputs.Player.Jump.performed += _ => OnJumpPressed?.Invoke();
            _snakesInputs.Player.Jump.canceled += _ => OnJumpReleased?.Invoke();
        }

        private void OnEnable() => _snakesInputs.Enable();

        private void OnDisable() => _snakesInputs.Disable();
    }
}
