using UnityEngine;

namespace Aureola.Accessories
{
    public class ConfigManager : ConfigService
    {
        private static ConfigManager _instance;

        public static ConfigManager instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = this;
        }
    }
}
