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

        public void Set(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
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

        public bool Get(string key, bool defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
