using Aureola.PubSub;
using Aureola.Storage;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Aureola.Config
{
    public class ConfigManager : MonoBehaviour
    {
        private static ConfigService _service;

        [Header("Settings")]
        [SerializeField] private AssetReference _configFile;

        public static ConfigService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new ConfigService();
            _service.onLoaded += OnConfigLoaded;
            _service.Load(_configFile);
        }

        private void OnConfigLoaded()
        {
            PubSubManager.service?.Send(Channel.CONFIG, new ConfigLoaded());
        }
    }
}
