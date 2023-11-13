using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "SettingsLoaded", menuName = "Aureola/Events/SettingsLoaded")]
    public class SettingsLoadedEvent : ScriptableObject
    {
        public delegate void SettingsLoaded();
        private event SettingsLoaded _onSettingsLoaded;

        public void Subscribe(SettingsLoaded callback)
        {
            _onSettingsLoaded += callback;
        }

        public void Unsubscribe(SettingsLoaded callback)
        {
            _onSettingsLoaded -= callback;
        }

        public void Invoke()
        {
            _onSettingsLoaded?.Invoke();
        }
    }
}
