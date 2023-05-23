using UnityEngine;

namespace Aureola.Storage
{
    public class RuntimeStorageManager : MonoBehaviour
    {
        private static RuntimeStorageService _instance;

        public static RuntimeStorageService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new RuntimeStorageService();
        }
    }
}