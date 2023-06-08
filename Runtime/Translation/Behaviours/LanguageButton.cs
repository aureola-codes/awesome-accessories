using Aureola.Interface;
using UnityEngine;

namespace Aureola.Translation
{
    public class LanguageButton : ClickableButton
    {
        [SerializeField] private string _language;

        public void OnClick()
        {
            TranslationManager.service?.ChangeLanguage(_language);
        }
    }
}
