using System;
using Data;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public event Action<PlayerData, Vector2> OnPlayerMove;
        public event Action OnPlayerStopMove;
        public event Action OnPlayerStopThrow;
        
        public event Action OnPlayerTouchedBall;
        
        [SerializeField] private PlayerData playerData;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var position = Tools.MainCamera.ScreenToWorldPoint(Input.mousePosition);
                OnPlayerMove?.Invoke(playerData, position);
            }
        }

        private void StopMove()
        {
            OnPlayerStopMove?.Invoke();
        }

        private void StopThrow()
        {
            OnPlayerStopThrow?.Invoke();
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ball"))
            {
                var ballTrm = other.transform.parent;
                OnPlayerTouchedBall?.Invoke();
                OnPlayerStopMove?.Invoke();
                
                Destroy(ballTrm.gameObject);
            }
        }
    }
}