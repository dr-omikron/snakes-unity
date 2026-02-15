using UnityEngine;

namespace _SnakesGame.Scripts.Character
{
    [RequireComponent(typeof(GameplayInputManager))]
    [RequireComponent(typeof(CharacterMovementComponent))]
    [RequireComponent(typeof(CharacterRotationComponent))]
    [RequireComponent(typeof(CharacterJumpHandler))]
    [RequireComponent(typeof(AnimationsController))]

    public class CharacterMovementHandler : MonoBehaviour
    {
        private GameplayInputManager _gameplayInputManager;
        private CharacterMovementComponent _characterMovementComponent;
        private CharacterRotationComponent _characterRotationComponent;
        private CharacterJumpHandler _characterJumpHandler;
        private AnimationsController _animationsController;

        private Vector3 _moveDirection;
        private bool _isGrounded;
        private bool _isFalling;
        private bool _isJumping;

        private void Awake()
        {
            _gameplayInputManager = GetComponent<GameplayInputManager>();
            _characterMovementComponent = GetComponent<CharacterMovementComponent>();
            _characterRotationComponent = GetComponent<CharacterRotationComponent>();
            _characterJumpHandler = GetComponent<CharacterJumpHandler>();
            _animationsController = GetComponent<AnimationsController>();

            _gameplayInputManager.OnMoveInputReceived += OnMoveStarted;
            _gameplayInputManager.OnMoveInputCancelled += OnMoveCanceled;
            _gameplayInputManager.OnJumpPressed += OnJump;

        }

        private void FixedUpdate()
        {
            UpdateMovementStateFlags();
            HandlingMovement();
            UpdateAnimationFlags();
        }

        private void UpdateMovementStateFlags()
        {
            _isGrounded = _characterJumpHandler.IsGrounded();
            _isFalling = _characterJumpHandler.IsFalling();
            _isJumping = _characterJumpHandler.IsJumping();
        }

        private void HandlingMovement()
        {
            _characterMovementComponent.MoveCharacter(_moveDirection);
            _characterRotationComponent.RotateCharacter(_moveDirection);
        }

        private void UpdateAnimationFlags()
        {
            _animationsController.SetAnimatorIsGrounded(_isGrounded);
            _animationsController.SetAnimatorIsFalling(_isFalling);
            _animationsController.SetAnimatoIsJump(_isJumping);
        }

        private void OnMoveStarted(Vector2 value)
        {
            _moveDirection.x = -value.x; 
            _moveDirection.z = -value.y;
            _animationsController.SetAnimatorIsMoving(true);
        }

        private void OnMoveCanceled()
        {
            _moveDirection.x = 0;
            _moveDirection.z = 0;
            _animationsController.SetAnimatorIsMoving(false);
        }

        private void OnJump() => _characterJumpHandler.HandleJump();
    }
}
