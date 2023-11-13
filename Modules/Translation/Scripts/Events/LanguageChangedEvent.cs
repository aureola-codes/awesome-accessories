using UnityEngine;

namespace Aureola.Translation
{
    [CreateAssetMenu(fileName = "LanguageChanged", menuName = "Aureola/Events/LanguageChanged")]
    public class LanguageChangedEvent : ScriptableObject
    {
        public delegate void LanguageChanged(SystemLanguage language);
        private event LanguageChanged _onLanguageChanged;

        public void Subscribe(LanguageChanged callback)
        {
            _onLanguageChanged += callback;
        }

        public void Unsubscribe(LanguageChanged callback)
        {
            _onLanguageChanged -= callback;
        }

        public void Invoke(SystemLanguage language)
        {
            _onLanguageChanged?.Invoke(language);
        }
    }
}
