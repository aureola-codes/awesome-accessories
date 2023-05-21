using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Aureola.Accessories
{
    public class ConfigManager : MonoBehaviour
    {
        private static ConfigService _instance;

        [Header("Settings")]
        [SerializeField] private AssetReference _configFile;

        public static ConfigService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new ConfigService();
            _instance.Load(_configFile);
        }
    }
}
