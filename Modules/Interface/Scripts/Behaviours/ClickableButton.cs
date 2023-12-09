using Aureola.Audio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola.Interface
{
    public class ClickableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private float _zoomUp = 1f;
        private float _zoomDown = 0.95f;

        [Header("Settings")]
        [SerializeField] private AudioClip _sound;

        [Header("Dependencies")]
        [SerializeField] private AudioManager _audioManager;

        private void Awake()
        {
            if (_audioManager == null) {
                _audioManager = SOLocator.Get<AudioManager>();
            }
        }

        public void OnPointerDown(PointerEventData data)
        {
            if (_sound != null) {
                _audioManager.PlaySound(_sound);
            }

            transform.localScale = new Vector3(_zoomDown, _zoomDown, _zoomDown);
        }

        public void OnPointerUp(PointerEventData data)
        {
            transform.localScale = new Vector3(_zoomUp, _zoomUp, _zoomUp);
        }
    }
}
