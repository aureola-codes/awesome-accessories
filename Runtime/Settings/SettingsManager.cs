using Aureola.PubSub;
using Aureola.Storage;
using UnityEngine;

namespace Aureola.Settings
{
    public class SettingsManager : MonoBehaviour
    {
        private static SettingsService _service;

        public static SettingsService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new SettingsService(new SimpleStorageService(), new SettingsData());
            _service.onUpdate += OnUpdate;
        }

        private void OnUpdate(ISettingsData settingsData)
        {
            PubSubManager.service?.Send(Channel.SETTINGS, new SettingsUpdated(settingsData));
        }
    }
}
