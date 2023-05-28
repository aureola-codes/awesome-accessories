using UnityEngine;

namespace Aureola.Video
{
    public class VideoService
    {
        private Camera _camera;

        public Camera camera
        {
            get => _camera;
        }

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

        public void EnableAudioListener()
        {
            _camera.GetComponent<AudioListener>().enabled = true;
        }

        public void DisableAudioListener()
        {
            _camera.GetComponent<AudioListener>().enabled = false;
        }
    }
}
