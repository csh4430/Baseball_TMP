using System;
using UnityEngine;
using Utils;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public event Action<Vector2> OnPlayerMove;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var position = Tools.MainCamera.ScreenToWorldPoint(Input.mousePosition);
                OnPlayerMove?.Invoke(position);
            }
        }
    }
}