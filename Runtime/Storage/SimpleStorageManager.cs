using UnityEngine;

namespace Aureola.Storage
{
    public class SimpleStorageManager : MonoBehaviour
    {
        private static SimpleStorageService _instance;

        public static SimpleStorageService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new SimpleStorageService();
        }
    }
}
