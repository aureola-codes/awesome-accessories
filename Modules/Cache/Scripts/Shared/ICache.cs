using UnityEngine;

namespace Aureola.Cache
{
    public interface ICache
    {
        public bool isReady { get; }

        public void Set(string key, int value);
        public void Set(string key, float value);
        public void Set(string key, string value);
        public void Set(string key, bool value);
        public void Set(string key, Vector2 value);
        public void Set(string key, Vector3 value);
        public void Set(string key, Vector4 value);
        public void Set(string key, Color value);
        public void Set(string key, Color32 value);
        public void Set(string key, Quaternion value);

        public int Get(string key, int defaultValue);
        public float Get(string key, float defaultValue);
        public string Get(string key, string defaultValue);
        public bool Get(string key, bool defaultValue);
        public Vector2 Get(string key, Vector2 defaultValue);
        public Vector3 Get(string key, Vector3 defaultValue);
        public Vector4 Get(string key, Vector4 defaultValue);
        public Color Get(string key, Color defaultValue);
        public Color32 Get(string key, Color32 defaultValue);
        public Quaternion Get(string key, Quaternion defaultValue);

        public void Clear();
    }
}
