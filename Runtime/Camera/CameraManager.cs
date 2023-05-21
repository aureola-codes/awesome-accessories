using UnityEngine;

namespace Aureola.Accessories
{
    public class CameraManager : MonoBehaviour
    {
        private static CameraService _instance;

        [Header("Settings")]
        [SerializeField] private Camera _camera;
        
        public static CameraService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new CameraService(_camera);
        }
    }
}
