using UnityEngine;

namespace Aureola.Accessories
{
    public class CameraService
    {
        private Camera _camera;

        public CameraService(Camera camera)
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
