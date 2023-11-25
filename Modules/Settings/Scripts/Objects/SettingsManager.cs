using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SimpleJSON;
using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "SettingsManager", menuName = "Aureola/Settings/SettingsManager", order = 18)]
    public class SettingsManager : ScriptableObject
    {
        private bool _isReady = false;
        private Settings _settings = new Settings();

        public delegate void SettingsChanged(Settings settings);
        public delegate void SettingsLoaded();
        public delegate void SettingsStored();

        public event SettingsChanged onChanged;
        public event SettingsLoaded onLoaded;
        public event SettingsStored onStored;

        [Header("Dependencies")]
        [SerializeField] private SettingsStorage _storage;

        public bool isReady
        {
            get => _isReady;
        }

        public void Load()
        {
            _storage.onLoaded += (settings) => {
                _settings = settings;
                _isReady = true;

                onLoaded?.Invoke();
            };

            _storage.Load();
        }

        public void Save()
        {
            _storage.onStored += (settings) => {
                onStored?.Invoke();
            };

            _storage.Save(_settings);
        }

        public void Reset()
        {
            _isReady = false;
            _settings = new Settings();
        }

        public int Get(string key, int defaultValue)
        {
            var value = (int?) GetField(key)?.GetValue(_settings);
            return (int) (value != null ? value : defaultValue);
        }

        public float Get(string key, float defaultValue)
        {
            var value = (float?) GetField(key)?.GetValue(_settings);
            return (float) (value != null ? value : defaultValue);
        }

        public string Get(string key, string defaultValue)
        {
            var value = (string) GetField(key)?.GetValue(_settings);
            return value != null ? value : defaultValue;
        }

        public void Set(string key, int value)
        {
            Debug.Log(key);

            GetField(key)?.SetValue(_settings, value);
            onChanged?.Invoke(_settings);
        }

        public void Set(string key, float value)
        {
            GetField(key)?.SetValue(_settings, value);    
            onChanged?.Invoke(_settings);
        }

        public void Set(string key, string value)
        {
            GetField(key)?.SetValue(_settings, value);
            onChanged?.Invoke(_settings);
        }

        protected FieldInfo GetField(string fieldName)
        {
            return _settings.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }
    }
}
