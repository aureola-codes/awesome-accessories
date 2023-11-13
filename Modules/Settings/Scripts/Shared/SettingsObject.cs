using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Aureola/Shared/Settings")]
    public class SettingsObject : ScriptableObject
    {
        private Settings _settings = new Settings();

        [Header("Dependencies")]
        [SerializeField] private SettingsStorage _storage;

        [Header("Events")]
        [SerializeField] private SettingsChangedEvent _onSettingsChanged;
        [SerializeField] private SettingsLoadedEvent _onSettingsLoaded;
        [SerializeField] private SettingsStoredEvent _onSettingsStored;

        public void Load()
        {
            // TODO: Do loading stuff.
            _onSettingsLoaded.Invoke();
        }

        public void Save()
        {
            // TODO: Do storage stuff.
            _onSettingsStored.Invoke();
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

        public void Set(string key, int value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);
                _onSettingsChanged.Invoke(_settings);
            }
        }

        public void Set(string key, float value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);    
                _onSettingsChanged.Invoke(_settings);
            }
        }

        public void Set(string key, string value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);
                _onSettingsChanged.Invoke(_settings);
            }
        }

        public void Set(string key, bool value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);
                _onSettingsChanged.Invoke(_settings);
            }
        }

        private System.Reflection.FieldInfo GetField(string fieldName)
        {
            return _settings.GetType().GetField(fieldName);
        }
    }
}
