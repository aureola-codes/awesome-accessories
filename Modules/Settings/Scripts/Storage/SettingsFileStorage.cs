using System.IO;
using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "SettingsFileStorage", menuName = "Aureola/Settings/SettingsFileStorage")]
    public class SettingsFileStorage : SettingsStorage
    {
        private string filePath
        {
            get => $"{Application.persistentDataPath}{_basePath}{_fileName}.json";
        }

        [Header("Settings")]
        [SerializeField] private string _basePath = "/";
        [SerializeField] private string _fileName = "settings";

        public override void Load()
        {
            LoadAsync();
        }

        public override void Save(SettingsData settings)
        {
            SaveAsync(settings);
        }

        private async void LoadAsync()
        {
            try {
                var json = await System.IO.File.ReadAllTextAsync(filePath);
                RaiseOnLoaded(SettingsData.FromJson(json));
            } catch (System.Exception e) {
                RaiseOnError(e.Message);
            }
        }

        private async void SaveAsync(SettingsData settings)
        {
            try {
                await System.IO.File.WriteAllTextAsync(filePath, settings.ToJson());
                RaiseOnStored(settings);
            } catch (System.Exception e) {
                RaiseOnError(e.Message);
            }
        }
    }
}
