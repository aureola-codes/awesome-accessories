using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "SimpleSettingsDriver", menuName = "Aureola/SimpleSettingsDriver", order = 21)]
    public class SimpleSettingsDriver : BaseSettingsDriver
    {
        [Header("Settings")]
        [SerializeField] private string _storageKey = "settings";

        public override void Load()
        {
            var json = PlayerPrefs.GetString(_storageKey, "{}");
            var settings = SettingsData.FromJson(json);
            RaiseOnLoaded(settings);
        }

        public override void Save(SettingsData settings)
        {
            PlayerPrefs.SetString(_storageKey, settings.ToJson());
            RaiseOnStored(settings);
        }
    }
}
