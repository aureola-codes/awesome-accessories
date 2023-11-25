using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SimpleJSON;
using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "SettingsManager", menuName = "Aureola/Settings/SettingsManager", order = 18)]
    public class SettingsManager : ScriptableObject, IResettable
    {
        private bool _isReady = false;
        private SettingsData _settings = new SettingsData();

        public delegate void SettingsChanged();
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
            _settings = new SettingsData();
        }

        public int Get(string key, int defaultValue)
        {
            return _settings.Get(key, defaultValue);
        }

        public float Get(string key, float defaultValue)
        {
            return _settings.Get(key, defaultValue);
        }

        public string Get(string key, string defaultValue)
        {
            return _settings.Get(key, defaultValue);
        }

        public bool Get(string key, bool defaultValue)
        {
            return _settings.Get(key, defaultValue);
        }

        public void Set(string key, int value)
        {
            _settings.Set(key, value);
            onChanged?.Invoke();
        }

        public void Set(string key, float value)
        {
            _settings.Set(key, value);
            onChanged?.Invoke();
        }

        public void Set(string key, string value)
        {
            _settings.Set(key, value);
            onChanged?.Invoke();
        }

        public void Set(string key, bool value)
        {
            _settings.Set(key, value);
            onChanged?.Invoke();
        }
    }
}
