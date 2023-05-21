using UnityEngine;
using TMPro;

namespace Aureola.Accessories
{
    public class DigitalClock : MonoBehaviour
    {
        private TMP_Text _textComponent;

        private void Awake()
        {
            _textComponent = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            InvokeRepeating("UpdateTime", 0f, 1f);
        }

        private void OnDestroy()
        {
            CancelInvoke("UpdateTime");
        }

        private void UpdateTime()
        {
            _textComponent.text = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");
        }
    }
}
