using Aureola.Interface;
using UnityEngine;

namespace Aureola.Translation
{
    public class SystemLanguageButton : ClickableButton
    {
        [Header("Settings")]
        [SerializeField] private SystemLanguage _language;

        [Header("Dependencies")]
        [SerializeField] private TranslationsObject _translations;

        public void OnClick()
        {
            _translations.SetLanguage(_language);
        }
    }
}
