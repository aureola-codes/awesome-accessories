using System.IO;
using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "FileSettingsDriver", menuName = "Aureola/FileSettingsDriver", order = 7)]
    public class FileSettingsDriver : BaseSettingsDriver
    {
        [Header("Settings")]
        [SerializeField] private string _basePath = "/";
        [SerializeField] private string _fileName = "settings";

        public override void Load()
        {
            // Makes no sense to load settings if the file doesn't exist.
            if (!File.Exists(GetStoragePath())) {
                RaiseOnLoaded(new SettingsData());
                return;
            }

            LoadAsync();
        }

        public override void Save(SettingsData settings)
        {
            SaveAsync(settings);
        }

        private async void LoadAsync()
        {
            try {
                var json = await File.ReadAllTextAsync(GetStoragePath());
                RaiseOnLoaded(SettingsData.FromJson(json));
            } catch (System.Exception e) {
                RaiseOnError(e.Message);
            }
        }

        private async void SaveAsync(SettingsData settings)
        {
            try {
                await File.WriteAllTextAsync(GetStoragePath(), settings.ToJson());
                RaiseOnStored(settings);
            } catch (System.Exception e) {
                RaiseOnError(e.Message);
            }
        }

        private string GetStoragePath()
        {
            return $"{Application.persistentDataPath}{_basePath}{_fileName}.json";
        }
    }
}
