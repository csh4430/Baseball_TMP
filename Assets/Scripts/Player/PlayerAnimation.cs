using Data;
using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        
        private readonly int _x = Animator.StringToHash("x_Input");
        private readonly int _y = Animator.StringToHash("y_Input");
        private readonly int _movementSpeed = Animator.StringToHash("MovementSpeed");
        private readonly int _ballState = Animator.StringToHash("BallState");
        private readonly int _isBallOverHead = Animator.StringToHash("IsBallOver");
        private readonly int _isFielding = Animator.StringToHash("IsFielding");

        private void Awake()
        {
            var playerController = GetComponent<PlayerController>();
            playerController.OnPlayerMove += PlayAnimation_OnMove; 
            playerController.OnPlayerStopMove += PlayAnimationOnStopMove;
            playerController.OnPlayerTouchedBall += PlayAnimation_OnTouchedBall;
            playerController.OnPlayerStopThrow += PlayAnimation_OnStopThrow;
        }

        private void PlayAnimation_OnStopThrow()
        {
            playerAnimator.SetInteger(_ballState, 0);
        }

        private void PlayAnimation_OnTouchedBall()
        {
            playerAnimator.SetInteger(_ballState, 1);
            playerAnimator.SetTrigger(_isBallOverHead);
            playerAnimator.SetTrigger(_isFielding);
            
        }

        private void PlayAnimationOnStopMove()
        {
            playerAnimator.SetFloat(_x, 0);
            playerAnimator.SetFloat(_y, 0);
            playerAnimator.SetFloat(_movementSpeed, -1);
        }

        private void PlayAnimation_OnMove(PlayerData playerData, Vector2 pos)
        {
            var dir = pos - (Vector2) transform.position;
            dir = dir.normalized;
            playerAnimator.SetFloat(_x, dir.x);
            playerAnimator.SetFloat(_y, dir.y);
            playerAnimator.SetFloat(_movementSpeed, playerData.movementSpeed * 0.3f);
        }
    }
}