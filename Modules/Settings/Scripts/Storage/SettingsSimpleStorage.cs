using Aureola;
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
            var settings = SettingsData.FromJson(json);

            Debug.Log(json);
            
            RaiseOnLoaded(settings);
        }

        public override void Save(SettingsData settings)
        {
            PlayerPrefs.SetString(_storageKey, settings.ToJson());
            RaiseOnStored(settings);
        }
    }
}
