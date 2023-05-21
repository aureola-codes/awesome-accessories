using UnityEngine;

namespace Aureola.Accessories
{
    public class CameraManager : CameraService
    {
        private static CameraManager _instance;
        
        public static CameraManager instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = this;
        }
    }
}
