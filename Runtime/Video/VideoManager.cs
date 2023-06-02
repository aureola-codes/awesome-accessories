using UnityEngine;

namespace Aureola.Video
{
    public class VideoManager : MonoBehaviour
    {
        private static VideoService _service;

        [Header("Settings")]
        [SerializeField] private Camera _camera;
        
        public static VideoService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new VideoService(_camera);
        }
    }
}
