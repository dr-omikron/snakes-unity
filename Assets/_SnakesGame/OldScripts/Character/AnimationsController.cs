using UnityEngine;

namespace _SnakesGame.Scripts.Character
{
    public class AnimationsController : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int IsJump = Animator.StringToHash("IsJump");
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        private static readonly int IsFalling = Animator.StringToHash("IsFalling");
        private static readonly int StartAttack = Animator.StringToHash("StartAttack");
        private static readonly int Damaged = Animator.StringToHash("Damaged");
        private static readonly int IsLongAttack = Animator.StringToHash("IsLongAttack");

        [SerializeField] private Animator _snakeAnimator;

        public void SetAnimatorIsMoving(bool isMoving) => _snakeAnimator.SetBool(IsMoving, isMoving);
        public void SetAnimatorIsGrounded(bool isGrounded) => _snakeAnimator.SetBool(IsGrounded, isGrounded);
        public void SetAnimatorIsFalling(bool isFalling) => _snakeAnimator.SetBool(IsFalling, isFalling);
        public void SetAnimatoIsJump(bool isJumping) => _snakeAnimator.SetBool(IsJump, isJumping);
        public void SetAnimatorStartAttackTrigger() => _snakeAnimator.SetTrigger(StartAttack);

        public void SetAnimatorIsLongAttack(bool isLong) => _snakeAnimator.SetBool(IsLongAttack, isLong);

        public void SetAnimatorDamagedTrigger() => _snakeAnimator.SetTrigger(Damaged);
    }
}
