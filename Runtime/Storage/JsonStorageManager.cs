using UnityEngine;

namespace Aureola.Storage
{
    public class JsonStorageManager : MonoBehaviour
    {
        private static JsonStorageService _service;

        [Header("Settings")]
        [SerializeField] private string _basePath = "";
        [SerializeField] private string _fileName = "storage.json";

        public static JsonStorageService service
        {
            get => _service;
        }

        private void Awake()
        {
            var basePath = _basePath == "" ? Application.persistentDataPath : _basePath;
            _service = new JsonStorageService(basePath, _fileName);
        }
    }
}
