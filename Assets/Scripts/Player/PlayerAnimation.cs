using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;

        private void Awake()
        {
            var playerController = GetComponent<PlayerController>();
            playerController.OnPlayerMove += PlayAnimation_OnMove; 
        }

        private void PlayAnimation_OnMove(Vector2 pos)
        {
            var dir = pos - (Vector2) transform.position;
            dir = dir.normalized;
            playerAnimator.SetFloat("x", dir.x);
            playerAnimator.SetFloat("y", dir.y);
        }
    }
}