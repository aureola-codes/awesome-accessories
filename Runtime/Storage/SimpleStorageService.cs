using UnityEngine;

namespace Aureola.Accessories
{
    public class SimpleStorageService : IStorageService
    {
        public void Set(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public void Set(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }

        public void Set(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        public int Get(string key, int defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public float Get(string key, float defaultValue)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }

        public string Get(string key, string defaultValue)
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
