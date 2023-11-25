using Aureola.Interface;
using UnityEngine;

namespace Aureola.Translations
{
    public class LanguageButton : ClickableButton
    {
        [Header("Settings")]
        [SerializeField] private string _language;

        [Header("Dependencies")]
        [SerializeField] private TranslationManager _translations;

        public void OnClick()
        {
            _translations.SetLanguage(_language);
        }
    }
}
