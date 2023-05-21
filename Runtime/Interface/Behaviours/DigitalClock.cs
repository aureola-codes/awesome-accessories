using System.Collections;
using UnityEngine;
using TMPro;

namespace Aureola.Accessories
{
    [RequireComponent(typeof(TMP_Text))]
    public class DigitalClock : MonoBehaviour
    {
        private TMP_Text _textComponent;
        [SerializeField] private string _format = "HH:mm";

        private void Awake()
        {
            _textComponent = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            StartCoroutine(UpdateTime());
        }

        private void OnDisable()
        {
            StopCoroutine(UpdateTime());
        }

        private IEnumerator UpdateTime()
        {
            while (true)
            {
                _textComponent.text = System.DateTime.UtcNow.ToLocalTime().ToString(_format);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
