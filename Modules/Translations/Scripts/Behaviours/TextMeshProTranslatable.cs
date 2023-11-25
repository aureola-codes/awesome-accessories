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
        [SerializeField] private TranslationManager _translations;

        private void Awake()
        {
            _textField = GetComponent<TMP_Text>();
            _translationKey = _textField.text;
        }

        private void OnEnable()
        {
            Render();
            _translations.onChanged += OnLanguageChanged;
        }

        private void OnDisable()
        {
            _translations.onChanged -= OnLanguageChanged;
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

            _textField.text = _translations.Get(_translationKey);
        }
    }
}