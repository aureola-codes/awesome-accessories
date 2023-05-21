using TMPro;
using UnityEngine;

namespace Aureola.Accessories
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextAutoHeight : MonoBehaviour
    {
        private TMP_Text _textElement;
        private RectTransform _rectTransform;
        private string _textOld;

        private void Awake()
        {
            _textElement = GetComponent<TMP_Text>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void LateUpdate()
        {
            if (_textElement.preferredHeight != _rectTransform.sizeDelta.y) {
                OnTextChanged();
                Debug.Log("Updated!");
            }
        }

        private void OnTextChanged()
        {
            // Get the preferred width and height of the rendered text
            float textWidth = _textElement.preferredWidth;
            float textHeight = _textElement.preferredHeight;

            // Adjust the size of the RectTransform component based on the size of the rendered text
            _rectTransform.sizeDelta = new Vector2(textWidth, textHeight);
        }
    }
}
