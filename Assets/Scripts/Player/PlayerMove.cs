using System;
using Data;
using DG.Tweening;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        private const Ease MoveEase = Ease.Flash;
        private Sequence _moveSeq;
        private PlayerController _playerController;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            _playerController.OnPlayerMove += Move;
            _playerController.OnPlayerStopMove += StopMove;
        }

        private void Move(PlayerData playerData, Vector2 position)
        {
            var dist = Vector2.Distance(transform.position, position);
            var time = dist / playerData.movementSpeed;
            _moveSeq.KillSequence();
            _moveSeq = DOTween.Sequence();
            _moveSeq.Append(transform.DOMove(position, time).SetEase(MoveEase));
            _moveSeq.AppendCallback(()=>
            {
                _playerController.Invoke("StopMove", 0);
                StopMove();
            });
        }

        private void StopMove()
        {
            _moveSeq.KillSequence();
        }
    }
}