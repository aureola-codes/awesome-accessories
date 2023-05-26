using UnityEngine;

namespace Aureola.Storage
{
    public class JsonStorageManager : MonoBehaviour
    {
        private static JsonStorageService _instance;

        [Header("Settings")]
        [SerializeField] private string _basePath = "";
        [SerializeField] private string _fileName = "storage.json";

        public static JsonStorageService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            var basePath = _basePath == "" ? Application.persistentDataPath : _basePath;
            _instance = new JsonStorageService(basePath, _fileName);
        }
    }
}
