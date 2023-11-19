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
            var json = System.IO.File.ReadAllText(filePath);
            var settings = JsonUtility.FromJson<Settings>(json);
            
            RaiseOnLoaded(settings);
        }

        public override void Save(Settings settings)
        {
            var json = JsonUtility.ToJson(settings);
            System.IO.File.WriteAllText(filePath, json);
            
            RaiseOnStored(settings);
        }
    }
}
