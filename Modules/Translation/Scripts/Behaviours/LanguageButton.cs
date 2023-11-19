using UnityEngine;

namespace Aureola.Translation
{
    public class LanguageButton : ClickableButton
    {
        [Header("Settings")]
        [SerializeField] private string _language;

        [Header("Dependencies")]
        [SerializeField] private TranslationsObject _translations;

        public void OnClick()
        {
            _translations.SetLanguage(_language);
        }
    }
}
