using UnityEngine;

namespace Aureola.Storage
{
    public class SimpleStorageManager : MonoBehaviour
    {
        private static SimpleStorageService _service;

        public static SimpleStorageService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new SimpleStorageService();
        }
    }
}
