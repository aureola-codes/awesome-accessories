using Aureola.Interface;
using UnityEngine;

namespace Aureola.Translations
{
    public class SystemLanguageButton : ClickableButton
    {
        [Header("Settings")]
        [SerializeField] private SystemLanguage _language;

        [Header("Dependencies")]
        [SerializeField] private TranslationsManager _translations;

        public void OnClick()
        {
            _translations.SetLanguage(_language);
        }
    }
}
