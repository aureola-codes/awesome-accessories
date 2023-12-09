using Aureola.Interface;
using UnityEngine;

namespace Aureola.Translations
{
    public class SystemLanguageButton : ClickableButton
    {
        [Header("Settings")]
        [SerializeField] private SystemLanguage _language;

        [Header("Dependencies")]
        [SerializeField] private TranslationsManager _translationsManager;

        private void Awake()
        {
            if (_translationsManager == null) {
                _translationsManager = SOLocator.Get<TranslationsManager>();
            }
        }

        public void OnClick()
        {
            _translationsManager.SetLanguage(_language);
        }
    }
}
