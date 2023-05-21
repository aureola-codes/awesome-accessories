using UnityEngine;

namespace Aureola.Accessories
{
    public class SettingsManager : SettingsService
    {
        private static SettingsManager _instance;

        public static SettingsManager instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = this;
            _instance.storage = SimpleStorageManager.instance;
            _instance.settings = new SettingsData();
        }
    }
}
