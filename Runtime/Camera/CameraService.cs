using UnityEngine;

namespace Aureola.Accessories
{
    public class CameraService : MonoBehaviour
    {
        [SerializeField] protected Camera _camera;

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
