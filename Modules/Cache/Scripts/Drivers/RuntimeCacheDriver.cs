using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Cache
{
    [CreateAssetMenu(fileName = "RuntimeCache", menuName = "Aureola/Cache/RuntimeCache", order = 17)]
    public class RuntimeCacheDriver : ScriptableObject, ICacheDriver
    {
        private Dictionary<string, object> _values = new Dictionary<string, object>();

        public bool IsReady => true;

        public void Set(string key, int value)
        {
            _values[key] = value;
        }

        public void Set(string key, float value)
        {
            _values[key] = value;
        }

        public void Set(string key, string value)
        {
            _values[key] = value;
        }

        public void Set(string key, bool value)
        {
            _values[key] = value;
        }

        public void Set(string key, Vector2 value)
        {
            _values[key] = value;
        }

        public void Set(string key, Vector3 value)
        {
            _values[key] = value;
        }

        public void Set(string key, Vector4 value)
        {
            _values[key] = value;
        }

        public void Set(string key, Color value)
        {
            _values[key] = value;
        }

        public void Set(string key, Color32 value)
        {
            _values[key] = value;
        }

        public void Set(string key, Quaternion value)
        {
            _values[key] = value;
        }

        public int Get(string key, int defaultValue)
        {
            if (!_values.ContainsKey(key)) {
                return defaultValue;
            }

            return (int) _values[key];
        }

        public float Get(string key, float defaultValue)
        {
            if (!_values.ContainsKey(key)) {
                return defaultValue;
            }

            return (float) _values[key];
        }

        public string Get(string key, string defaultValue)
        {
            if (!_values.ContainsKey(key)) {
                return defaultValue;
            }

            return (string) _values[key];
        }

        public bool Get(string key, bool defaultValue)
        {
            if (!_values.ContainsKey(key)) {
                return defaultValue;
            }

            return (bool) _values[key];
        }

        public Vector2 Get(string key, Vector2 defaultValue)
        {
            if (!_values.ContainsKey(key)) {
                return defaultValue;
            }

            return (Vector2) _values[key];
        }

        public Vector3 Get(string key, Vector3 defaultValue)
        {
            if (!_values.ContainsKey(key)) {
                return defaultValue;
            }

            return (Vector3) _values[key];
        }

        public Vector4 Get(string key, Vector4 defaultValue)
        {
            if (!_values.ContainsKey(key)) {
                return defaultValue;
            }

            return (Vector4) _values[key];
        }

        public Color Get(string key, Color defaultValue)
        {
            if (!_values.ContainsKey(key)) {
                return defaultValue;
            }

            return (Color) _values[key];
        }

        public Color32 Get(string key, Color32 defaultValue)
        {
            if (!_values.ContainsKey(key)) {
                return defaultValue;
            }

            return (Color32) _values[key];
        }

        public Quaternion Get(string key, Quaternion defaultValue)
        {
            if (!_values.ContainsKey(key)) {
                return defaultValue;
            }

            return (Quaternion) _values[key];
        }

        public void Clear()
        {
            _values.Clear();
        }
    }
}
