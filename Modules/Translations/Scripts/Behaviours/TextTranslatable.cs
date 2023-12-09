using UnityEngine;
using UnityEngine.UI;

namespace Aureola.Translations
{
    [RequireComponent(typeof(Text))]
    public class TextTranslatable : MonoBehaviour
    {
        private string _translationKey;
        private Text _textField;

        [Header("Dependencies")]
        [SerializeField] private TranslationsManager _translationsManager;

        private void Awake()
        {
            _textField = GetComponent<Text>();
            _translationKey = _textField.text;
            if (_translationsManager == null) {
                _translationsManager = SOLocator.Get<TranslationsManager>();
            }
        }

        private void OnEnable()
        {
            Render();
            _translationsManager.onChanged += OnLanguageChanged;
        }

        private void OnDisable()
        {
            _translationsManager.onChanged -= OnLanguageChanged;
        }

        private void OnLanguageChanged(Translation translation)
        {
            Render();
        }

        private void Render()
        {
            if (_translationKey == null || _translationKey == "") {
                Debug.LogWarning("Translation key is empty.");
                return;
            }

            _textField.text = _translationsManager?.Get(_translationKey);
        }
    }
}
