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

        public delegate void OnChanged();
        public delegate void OnLoaded();
        public delegate void OnStored();
        public delegate void OnError(string message);

        public event OnChanged onChanged;
        public event OnLoaded onLoaded;
        public event OnStored onStored;
        public event OnError onError;

        [Header("Dependencies")]
        [SerializeField] private SettingsStorage _storage;

        public bool isReady
        {
            get => _isReady;
        }

        public void Load()
        {
            _storage.Reset();

            _storage.onError += (message) => {
                onError?.Invoke(message);
            };

            _storage.onLoaded += (settings) => {
                _settings = settings;
                _isReady = true;

                onLoaded?.Invoke();
            };

            _storage.Load();
        }

        public void Save()
        {
            _storage.Reset();

            _storage.onError += (message) => {
                onError?.Invoke(message);
            };

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

        public void Clear()
        {
            _settings.Clear();
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
            if (!_settings.Has(key) || _settings.Get(key, value) != value) {
                _settings.Set(key, value);
                onChanged?.Invoke();
            }
        }

        public void Set(string key, float value)
        {
            if (!_settings.Has(key) || _settings.Get(key, value) != value) {
                _settings.Set(key, value);
                onChanged?.Invoke();
            }
        }

        public void Set(string key, string value)
        {
            if (!_settings.Has(key) || _settings.Get(key, value) != value) {
                _settings.Set(key, value);
                onChanged?.Invoke();
            }
        }

        public void Set(string key, bool value)
        {
            if (!_settings.Has(key) || _settings.Get(key, value) != value) {
                _settings.Set(key, value);
                onChanged?.Invoke();
            }
        }
    }
}
