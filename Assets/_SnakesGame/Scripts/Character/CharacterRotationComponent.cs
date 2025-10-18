using UnityEngine;

namespace _SnakesGame.Scripts.Character
{
    public class CharacterRotationComponent : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;

        public void RotateCharacter(Vector3 moveDirection)
        {
            moveDirection.y = 0.0f;

            if (Vector3.Angle(transform.forward, moveDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(
                    transform.forward, 
                    moveDirection, 
                    _rotateSpeed, 
                    0.0f);

                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }
}
