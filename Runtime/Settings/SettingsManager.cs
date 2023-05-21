using UnityEngine;

namespace Aureola.Accessories
{
    public class SettingsManager : MonoBehaviour
    {
        private static SettingsService _instance;

        public static SettingsService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new SettingsService(new SimpleStorageService(), new SettingsData());
            _instance.onUpdate += OnUpdate;
        }

        private void OnUpdate(ISettingsData settingsData)
        {
            PubSubManager.instance?.Send(Channel.SETTINGS, new SettingsEvent(settingsData));
        }
    }
}
