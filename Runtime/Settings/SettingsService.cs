using Aureola.Storage;
using System;
using UnityEngine;

namespace Aureola.Settings
{
    public class SettingsService : MonoBehaviour
    {
        private const string STORAGE_KEY = "settings";

        private ISettingsData _settings;
        private IStorageService _storage;

        public delegate void OnUpdate(ISettingsData settings);
        public OnUpdate onUpdate;

        public SettingsService(IStorageService storage)
        {
            _storage = storage;
        }

        public SettingsService(IStorageService storage, ISettingsData settings)
        {
            _storage = storage;
            Register(settings);
        }

        public void Register(ISettingsData settings)
        {
            _settings = settings;
        }

        public void Load()
        {
            string settingsData = _storage.Get(STORAGE_KEY, "");
            if (settingsData != "") {
                _settings = _settings.FromJson(settingsData);
                Broadcast();
            }
        }

        public void Set(string key, int value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);
                SaveAndBroadcast();
            }
        }

        public void Set(string key, float value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);    
                SaveAndBroadcast();
            }
        }

        public void Set(string key, string value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);
                SaveAndBroadcast();
            }
        }

        public void Set(string key, bool value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);
                SaveAndBroadcast();
            }
        }

        public int Get(string key, int defaultValue)
        {
            var value = (int?) GetField(key).GetValue(_settings);
            return (int) (value != null ? value : defaultValue);
        }

        public float Get(string key, float defaultValue)
        {
            var value = (float?) GetField(key).GetValue(_settings);
            return (float) (value != null ? value : defaultValue);
        }

        public string Get(string key, string defaultValue)
        {
            var value = (string) GetField(key).GetValue(_settings);
            return value != null ? value : defaultValue;
        }

        public bool Get(string key, bool defaultValue)
        {
            var value = (bool?) GetField(key).GetValue(_settings);
            return (bool) (value != null ? value : defaultValue);
        }

        public void Toggle(string key)
        {
            Set(key, !Get(key, false));
        }

        public void Clear()
        {
            _settings = (ISettingsData) Activator.CreateInstance(_settings.GetType());
            SaveAndBroadcast();
        }

        private System.Reflection.FieldInfo GetField(string fieldName)
        {
            return _settings.GetType().GetField(fieldName);
        }

        private void Save()
        {
            _storage.Set(STORAGE_KEY, JsonUtility.ToJson(_settings));
        }

        private void Broadcast()
        {
            onUpdate?.Invoke(_settings);
        }

        private void SaveAndBroadcast() 
        {
            Save();
            Broadcast();
        }
    }
}
