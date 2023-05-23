using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Storage
{
    public class RuntimeStorageService : IStorageService
    {
        private Dictionary<string, bool> _boolValues = new Dictionary<string, bool>();
        private Dictionary<string, float> _floatValues = new Dictionary<string, float>();
        private Dictionary<string, int> _intValues = new Dictionary<string, int>();
        private Dictionary<string, string> _stringValues = new Dictionary<string, string>();
        private Dictionary<string, Vector2> _vector2Values = new Dictionary<string, Vector2>();
        private Dictionary<string, Vector3> _vector3Values = new Dictionary<string, Vector3>();
        private Dictionary<string, Vector4> _vector4Values = new Dictionary<string, Vector4>();
        private Dictionary<string, Color> _colorValues = new Dictionary<string, Color>();
        private Dictionary<string, Color32> _color32Values = new Dictionary<string, Color32>();
        private Dictionary<string, Quaternion> _quaternionValues = new Dictionary<string, Quaternion>();

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
            _vector2Values[key] = value;
        }

        public void Set(string key, Vector3 value)
        {
            _vector3Values[key] = value;
        }

        public void Set(string key, Vector4 value)
        {
            _vector4Values[key] = value;
        }

        public void Set(string key, Color value)
        {
            _colorValues[key] = value;
        }

        public void Set(string key, Color32 value)
        {
            _color32Values[key] = value;
        }

        public void Set(string key, Quaternion value)
        {
            _quaternionValues[key] = value;
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
            if (!_vector2Values.ContainsKey(key)) {
                return defaultValue;
            }

            return _vector2Values[key];
        }

        public Vector3 Get(string key, Vector3 defaultValue)
        {
            if (!_vector3Values.ContainsKey(key)) {
                return defaultValue;
            }

            return _vector3Values[key];
        }

        public Vector4 Get(string key, Vector4 defaultValue)
        {
            if (!_vector4Values.ContainsKey(key)) {
                return defaultValue;
            }

            return _vector4Values[key];
        }

        public Color Get(string key, Color defaultValue)
        {
            if (!_colorValues.ContainsKey(key)) {
                return defaultValue;
            }

            return _colorValues[key];
        }

        public Color32 Get(string key, Color32 defaultValue)
        {
            if (!_color32Values.ContainsKey(key)) {
                return defaultValue;
            }

            return _color32Values[key];
        }

        public Quaternion Get(string key, Quaternion defaultValue)
        {
            if (!_quaternionValues.ContainsKey(key)) {
                return defaultValue;
            }

            return _quaternionValues[key];
        }

        public void Clear()
        {
            _boolValues.Clear();
            _floatValues.Clear();
            _intValues.Clear();
            _stringValues.Clear();
            _vector2Values.Clear();
            _vector3Values.Clear();
            _vector4Values.Clear();
            _colorValues.Clear();
            _color32Values.Clear();
            _quaternionValues.Clear();
        }
    }
}
