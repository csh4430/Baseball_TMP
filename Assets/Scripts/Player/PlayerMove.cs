using System;
using DG.Tweening;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        private const Ease MoveEase = Ease.Flash;
        private Sequence _moveSeq;

        private void Awake()
        {
            var playerController = GetComponent<PlayerController>();
            playerController.OnPlayerMove += Move;
        }

        private void Move(Vector2 position)
        {
            var dist = Vector2.Distance(transform.position, position);
            var time = dist / speed;
            _moveSeq.KillSequence();
            _moveSeq = DOTween.Sequence();
            _moveSeq.Append(transform.DOMove(position, time).SetEase(MoveEase));
        }
    }
}