using UnityEngine;

namespace Aureola.Video
{
    public class VideoService
    {
        private Camera _camera;

        public VideoService(Camera camera)
        {
            _camera = camera;
        }

        public void EnableCamera()
        {
            _camera.gameObject.SetActive(true);
        }

        public void DisableCamera()
        {
            _camera.gameObject.SetActive(false);
        }
    }
}
