using UnityEngine;
using TMPro;

namespace Aureola.Translations
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextMeshProTranslatable : MonoBehaviour
    {
        private string _translationKey;
        private TMP_Text _textField;

        [Header("Dependencies")]
        [SerializeField] private TranslationsManager _translationsManager;

        private void Awake()
        {
            _textField = GetComponent<TMP_Text>();
            _translationKey = _textField.text;
            if (_translationsManager == null) {
                _translationsManager = SOLocator.Get<TranslationsManager>();
            }
        }

        private void OnEnable()
        {
            Render();
            _translationsManager.OnChanged += OnLanguageChanged;
        }

        private void OnDisable()
        {
            _translationsManager.OnChanged -= OnLanguageChanged;
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

            _textField.text = _translationsManager.Get(_translationKey);
        }
    }
}
