using Aureola.Interface;
using UnityEngine;

namespace Aureola.Translation
{
    public class SystemLanguageButton : ClickableButton
    {
        [SerializeField] private SystemLanguage _language;

        public void OnClick()
        {
            TranslationManager.service?.ChangeLanguage(_language);
        }
    }
}
