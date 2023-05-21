using UnityEngine;

namespace Aureola.Accessories
{
    public interface IStorageService
    {
        public void Set(string key, int value);
        public void Set(string key, float value);
        public void Set(string key, string value);
        public void Set(string key, bool value);
        public int Get(string key, int defaultValue);
        public float Get(string key, float defaultValue);
        public string Get(string key, string defaultValue);
        public bool Get(string key, bool defaultValue);
        public void Clear();
    }
}
