using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "SettingsManager", menuName = "Aureola/Settings/SettingsManager", order = 18)]
    public class SettingsManager : ScriptableObject, IResettable, ILocatable
    {
        private bool _isReady = false;
        private SettingsData _settings = new SettingsData();

        public delegate void SettingsChanged();
        public event SettingsChanged OnChanged;

        public delegate void SettingsLoaded();
        public event SettingsLoaded OnLoaded;

        public delegate void SettingsStored();
        public event SettingsStored OnStored;

        public delegate void SettingsError(string message);
        public event SettingsError OnError;

        [Header("Dependencies")]
        [SerializeField] private BaseSettingsDriver _driver;

        public bool IsReady
        {
            get => _isReady;
        }

        public SettingsData Data
        {
            get => _settings;
        }

        public void Load()
        {
            _isReady = false;

            _driver.Reset();
            _driver.OnError += (message) => {
                OnError?.Invoke(message);
            };
            _driver.OnLoaded += (settings) => {
                _settings = settings;
                _isReady = true;

                OnLoaded?.Invoke();
            };

            _driver.Load();
        }

        public void Save()
        {
            _driver.Reset();
            _driver.OnError += (message) => {
                OnError?.Invoke(message);
            };
            _driver.OnStored += (settings) => {
                OnStored?.Invoke();
            };

            _driver.Save(_settings);
        }

        public void Reset()
        {
            _isReady = false;
            _settings = new SettingsData();
            OnChanged?.Invoke();
        }

        public void Set<T>(string key, T value)
        {
            if (_settings.Get(key, value).Equals(value)) {
                return;
            }

            _settings.Set(key, value);
            OnChanged?.Invoke();
        }

        public T Get<T>(string key, T defaultValue)
        {
            return _settings.Get(key, defaultValue);
        }
    }
}
