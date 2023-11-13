using UnityEngine;

namespace Aureola.Settings
{
    abstract public class SettingsStorage : ScriptableObject
    {
        public delegate void OnLoaded(Settings settings);
        public event OnLoaded onLoaded;

        public delegate void OnStored(Settings settings);
        public event OnStored onStored;

        public abstract void Load();
        public abstract void Save(Settings settings);

        protected void RaiseOnStored(Settings settings)
        {
            onStored?.Invoke(settings);
        }

        protected void RaiseOnLoaded(Settings settings)
        {
            onLoaded?.Invoke(settings);
        }
    }
}
