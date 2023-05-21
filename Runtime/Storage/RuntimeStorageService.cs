using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Accessories
{
    public class RuntimeStorageService : IStorageService
    {
        protected Dictionary<string, bool> _boolValues = new Dictionary<string, bool>();
        protected Dictionary<string, float> _floatValues = new Dictionary<string, float>();
        protected Dictionary<string, int> _intValues = new Dictionary<string, int>();
        protected Dictionary<string, string> _stringValues = new Dictionary<string, string>();

        public void Set(string key, int value)
        {
            _intValues[key] = value;
        }

        public void Set(string key, float value)
        {
            _floatValues[key] = value;
        }

        public void Set(string key, string value)
        {
            _stringValues[key] = value;
        }

        public void Set(string key, bool value)
        {
            _boolValues[key] = value;
        }

        public void Set(string key, Vector2 value)
        {
            _stringValues[key] = $"{value.x},{value.y}";
        }

        public void Set(string key, Vector3 value)
        {
            _stringValues[key] = $"{value.x},{value.y},{value.z}";
        }

        public void Set(string key, Vector4 value)
        {
            _stringValues[key] = $"{value.x},{value.y},{value.z},{value.w}";
        }

        public void Set(string key, Color value)
        {
            _stringValues[key] = $"{value.r},{value.g},{value.b},{value.a}";
        }

        public void Set(string key, Color32 value)
        {
            _stringValues[key] = $"{value.r},{value.g},{value.b},{value.a}";
        }

        public void Set(string key, Quaternion value)
        {
            _stringValues[key] = $"{value.x},{value.y},{value.z},{value.w}";
        }

        public int Get(string key, int defaultValue)
        {
            if (!_intValues.ContainsKey(key)) {
                return defaultValue;
            }

            return _intValues[key];
        }

        public float Get(string key, float defaultValue)
        {
            if (!_floatValues.ContainsKey(key)) {
                return defaultValue;
            }

            return _floatValues[key];
        }

        public string Get(string key, string defaultValue)
        {
            if (!_stringValues.ContainsKey(key)) {
                return defaultValue;
            }

            return _stringValues[key];
        }

        public bool Get(string key, bool defaultValue)
        {
            if (!_boolValues.ContainsKey(key)) {
                return defaultValue;
            }

            return _boolValues[key];
        }

        public Vector2 Get(string key, Vector2 defaultValue)
        {
            if (!_stringValues.ContainsKey(key)) {
                return defaultValue;
            }

            var split = _stringValues[key].Split(',');
            if (split.Length != 2) {
                return defaultValue;
            }

            return new Vector2(float.Parse(split[0]), float.Parse(split[1]));
        }

        public Vector3 Get(string key, Vector3 defaultValue)
        {
            if (!_stringValues.ContainsKey(key)) {
                return defaultValue;
            }

            var split = _stringValues[key].Split(',');
            if (split.Length != 3) {
                return defaultValue;
            }

            return new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
        }

        public Vector4 Get(string key, Vector4 defaultValue)
        {
            if (!_stringValues.ContainsKey(key)) {
                return defaultValue;
            }

            var split = _stringValues[key].Split(',');
            if (split.Length != 4) {
                return defaultValue;
            }

            return new Vector4(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
        }

        public Color Get(string key, Color defaultValue)
        {
            if (!_stringValues.ContainsKey(key)) {
                return defaultValue;
            }

            var split = _stringValues[key].Split(',');
            if (split.Length != 4) {
                return defaultValue;
            }

            return new Color(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
        }

        public Color32 Get(string key, Color32 defaultValue)
        {
            if (!_stringValues.ContainsKey(key)) {
                return defaultValue;
            }

            var split = _stringValues[key].Split(',');
            if (split.Length != 4) {
                return defaultValue;
            }

            return new Color32(byte.Parse(split[0]), byte.Parse(split[1]), byte.Parse(split[2]), byte.Parse(split[3]));
        }

        public Quaternion Get(string key, Quaternion defaultValue)
        {
            if (!_stringValues.ContainsKey(key)) {
                return defaultValue;
            }

            var split = _stringValues[key].Split(',');
            if (split.Length != 4) {
                return defaultValue;
            }

            return new Quaternion(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]), float.Parse(split[3]));
        }

        public void Clear()
        {
            _boolValues = new Dictionary<string, bool>();
            _floatValues = new Dictionary<string, float>();
            _intValues = new Dictionary<string, int>();
            _stringValues = new Dictionary<string, string>();
        }
    }
}
