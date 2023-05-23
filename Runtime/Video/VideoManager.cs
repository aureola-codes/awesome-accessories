using UnityEngine;

namespace Aureola.Video
{
    public class VideoManager : MonoBehaviour
    {
        private static VideoService _instance;

        [Header("Settings")]
        [SerializeField] private Camera _camera;
        
        public static VideoService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new VideoService(_camera);
        }
    }
}
