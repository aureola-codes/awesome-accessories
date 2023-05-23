using UnityEngine;

namespace Aureola.Settings
{
    [System.Serializable]
    public class SettingsData : ISettingsData
    {
        public float masterVolume = 1f;
        public float musicVolume = 1f;
        public float soundVolume = 1f;
        public float voiceVolume = 1f;

        public ISettingsData FromJson(string jsonString)
        {
            return JsonUtility.FromJson<SettingsData>(jsonString);
        }
    }
}
