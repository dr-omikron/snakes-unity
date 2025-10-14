using UnityEngine;

namespace _SnakesGame.Scripts.Character
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(GameplayInputManager))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;

        private CharacterController _characterController;
        private GameplayInputManager _gameplayInputManager;
        private Vector3 _moveDirection;
        private bool _isMoving;

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _gameplayInputManager = GetComponent<GameplayInputManager>();

            _gameplayInputManager.OnMoveInputReceived += OnMove;
            _gameplayInputManager.OnMoveInputCancelled += OnMoveCanceled;
        }

        private void Update()
        {
            if (_isMoving == false)
                return;

            MoveCharacter(_moveDirection);
            RotateCharacter(_moveDirection);
        }

        private void MoveCharacter(Vector3 moveDirection)
        {
            Vector3 offset = moveDirection * _moveSpeed * Time.deltaTime;
            _characterController.Move(offset);
        }

        private void RotateCharacter(Vector3 moveDirection)
        {
            if (Vector3.Angle(transform.forward, moveDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }

        private void OnMove(Vector2 value)
        {
            _moveDirection = new Vector3(-value.x, 0, -value.y);
            _isMoving = true;
        }

        private void OnMoveCanceled() => _isMoving = false;
    }
}
