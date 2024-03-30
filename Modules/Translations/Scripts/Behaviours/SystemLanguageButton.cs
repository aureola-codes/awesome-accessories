using TMPro;
using UnityEngine;

namespace Aureola.Translations
{
    public class SystemLanguageButton : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private SystemLanguage _language;
        [SerializeField] private TextMeshProUGUI _label;

        [Header("Dependencies")]
        [SerializeField] private TranslationsManager _translationsManager;

        private void Awake()
        {
            if (_translationsManager == null) {
                _translationsManager = SOLocator.Get<TranslationsManager>();
            }
        }

        private void Start()
        {
            if (_label != null) {
                _label.text = _translationsManager.GetTranslation(_language)?.label;
            }
        }

        public void ChangeLanguage()
        {
            _translationsManager.SetLanguage(_language);
        }
    }
}
