using Aureola.PubSub;
using Aureola.Storage;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Aureola.Config
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
            _instance.onLoaded += OnConfigLoaded;
            _instance.Load(_configFile);
        }

        private void OnConfigLoaded()
        {
            PubSubManager.instance?.Send(Channel.CONFIG, new ConfigLoaded());
        }
    }
}
