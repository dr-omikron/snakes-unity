using UnityEngine;

namespace _SnakesGame.OldScripts.Character
{
    public class OnDrawGizmosDebug : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_collider.bounds.center, _collider.bounds.size);
        }
    }
}
