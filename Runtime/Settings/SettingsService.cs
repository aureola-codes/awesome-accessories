using UnityEngine;

namespace Aureola.Accessories
{
    public class SettingsService : MonoBehaviour
    {
        protected const string STORAGE_KEY = "settings";
        protected bool _shouldSave = false;

        protected ISettingsData _settings;
        protected IStorageService _storage;

        protected void Start()
        {
            string settingsData = _storage.Get(STORAGE_KEY, "");
            if (settingsData != "") {
                settings = _settings.FromJson(settingsData);
            }
        }

        protected void LateUpdate()
        {
            if (_shouldSave) {
                _shouldSave = false;
                _storage.Set(STORAGE_KEY, JsonUtility.ToJson(_settings));
            }
        }

        public IStorageService storage
        {
            set {
                _storage = value;
            }
        }

        public ISettingsData settings
        {
            set {
                _settings = value;
                _shouldSave = true;

                Broadcast();
            }
        }

        public void Set(string key, int value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);

                _shouldSave = true;
                Broadcast();
            }
        }

        public void Set(string key, float value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);
                        
                _shouldSave = true;
                Broadcast();
            }
        }

        public void Set(string key, string value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);

                _shouldSave = true;
                Broadcast();
            }
        }

        public void Set(string key, bool value)
        {
            if (Get(key, value) != value) {
                GetField(key).SetValue(_settings, value);
                
                _shouldSave = true;
                Broadcast();
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

        protected System.Reflection.FieldInfo GetField(string fieldName)
        {
            return _settings.GetType().GetField(fieldName);
        }
        
        protected void Broadcast()
        {
            PubSubManager.instance?.Send(Channel.SETTINGS, new SettingsEvent(_settings));
        }
    }
}
