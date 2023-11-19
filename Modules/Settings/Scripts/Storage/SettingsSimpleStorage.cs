using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "SettingsSimpleStorage", menuName = "Aureola/Settings/SettingsSimpleStorage")]
    public class SettingsSimpleStorage : SettingsStorage
    {
        [Header("Settings")]
        [SerializeField] private string _storageKey = "settings";

        public override void Load()
        {
            var json = PlayerPrefs.GetString(_storageKey, "{}");
            var settings = JsonUtility.FromJson<Settings>(json);
            
            RaiseOnLoaded(settings);
        }

        public override void Save(Settings settings)
        {
            var json = JsonUtility.ToJson(settings);
            PlayerPrefs.SetString(_storageKey, json);
            
            RaiseOnStored(settings);
        }
    }
}
