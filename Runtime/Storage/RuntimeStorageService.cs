using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Accessories
{
    public class RuntimeStorageService : MonoBehaviour, IStorageService
    {
        protected Dictionary<string, int> _intValues = new Dictionary<string, int>();
        protected Dictionary<string, float> _floatValues = new Dictionary<string, float>();
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

        public void Clear()
        {
            _intValues = new Dictionary<string, int>();
            _floatValues = new Dictionary<string, float>();
            _stringValues = new Dictionary<string, string>();
        }
    }
}
