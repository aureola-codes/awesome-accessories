using UnityEngine;

namespace Aureola.Accessories
{
    public class RuntimeStorageManager : RuntimeStorageService
    {
        private static RuntimeStorageManager _instance;

        public static RuntimeStorageManager instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = this;
        }
    }
}
