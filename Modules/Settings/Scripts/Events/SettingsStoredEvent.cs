using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "SettingsStored", menuName = "Aureola/Events/SettingsStored")]
    public class SettingsStoredEvent : ScriptableObject
    {
        public delegate void SettingsStored();
        private event SettingsStored _onSettingsStored;

        public void Subscribe(SettingsStored callback)
        {
            _onSettingsStored += callback;
        }

        public void Unsubscribe(SettingsStored callback)
        {
            _onSettingsStored -= callback;
        }

        public void Invoke()
        {
            _onSettingsStored?.Invoke();
        }
    }
}
