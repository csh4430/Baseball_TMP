using DG.Tweening;
using UnityEngine;

namespace Utils
{
    public static class Tools
    {
        private static Camera _mainCamera;
        
        public static Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }

                return _mainCamera;
            }
        }
        
        public static void KillSequence(this Sequence sequence)
        {
            if (sequence != null)
            {
                if (sequence.IsActive())
                {
                    if (sequence.IsPlaying())
                    {
                        sequence.Kill();
                    }
                }
            }
        }
    }
}