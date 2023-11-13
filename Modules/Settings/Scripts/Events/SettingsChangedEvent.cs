using UnityEngine;

namespace Aureola.Settings
{
    [CreateAssetMenu(fileName = "SettingsChanged", menuName = "Aureola/Events/SettingsChanged")]
    public class SettingsChangedEvent : ScriptableObject
    {
        public delegate void SettingsChanged(Settings settings);
        private event SettingsChanged _onSettingsChanged;

        public void Subscribe(SettingsChanged callback)
        {
            _onSettingsChanged += callback;
        }

        public void Unsubscribe(SettingsChanged callback)
        {
            _onSettingsChanged -= callback;
        }

        public void Invoke(Settings settings)
        {
            _onSettingsChanged?.Invoke(settings);
        }
    }
}
