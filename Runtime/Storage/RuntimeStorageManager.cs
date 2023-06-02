using UnityEngine;

namespace Aureola.Storage
{
    public class RuntimeStorageManager : MonoBehaviour
    {
        private static RuntimeStorageService _service;

        public static RuntimeStorageService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new RuntimeStorageService();
        }
    }
}
