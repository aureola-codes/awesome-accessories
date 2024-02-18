using UnityEngine;

namespace Aureola.Settings
{
    abstract public class BaseSettingsDriver : ScriptableObject
    {
        public delegate void SettingsLoaded(SettingsData settings);
        public event SettingsLoaded OnLoaded;

        public delegate void SettingsStored(SettingsData settings);
        public event SettingsStored OnStored;

        public delegate void SettingsError(string message);
        public event SettingsError OnError;

        public abstract void Load();
        public abstract void Save(SettingsData settings);

        public void Reset()
        {
            OnLoaded = null;
            OnStored = null;
            OnError = null;
        }

        protected void RaiseOnStored(SettingsData settings)
        {
            OnStored?.Invoke(settings);
        }

        protected void RaiseOnLoaded(SettingsData settings)
        {
            OnLoaded?.Invoke(settings);
        }

        protected void RaiseOnError(string message)
        {
            Debug.LogWarning(message);
            OnError?.Invoke(message);
        }
    }
}
