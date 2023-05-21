using UnityEngine;

namespace Aureola.Accessories
{
    public class SimpleStorageManager : SimpleStorageService
    {
        private static SimpleStorageManager _instance;

        public static SimpleStorageManager instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = this;
        }
    }
}
