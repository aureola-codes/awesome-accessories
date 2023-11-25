using UnityEngine;

namespace Aureola.Settings
{
    abstract public class SettingsStorage : ScriptableObject
    {
        public delegate void OnLoaded(SettingsData settings);
        public event OnLoaded onLoaded;

        public delegate void OnStored(SettingsData settings);
        public event OnStored onStored;

        public delegate void OnError(string message);
        public event OnError onError;

        public abstract void Load();
        public abstract void Save(SettingsData settings);

        protected void RaiseOnStored(SettingsData settings)
        {
            onStored?.Invoke(settings);
        }

        protected void RaiseOnLoaded(SettingsData settings)
        {
            onLoaded?.Invoke(settings);
        }

        protected void RaiseOnError(string message)
        {
            Debug.LogError(message);
            onError?.Invoke(message);
        }
    }
}
