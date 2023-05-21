
using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola.Accessories
{
    public class ClickableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private float _zoomUp = 1f;
        private float _zoomDown = 0.95f;

        [SerializeField] private AudioClip _sound;

        public void OnPointerDown(PointerEventData data)
        {
            if (_sound != null) {
                AudioManager.instance?.PlaySound(_sound);
            }

            transform.localScale = new Vector3(_zoomDown, _zoomDown, _zoomDown);
        }

        public void OnPointerUp(PointerEventData data)
        {
            transform.localScale = new Vector3(_zoomUp, _zoomUp, _zoomUp);
        }
    }
}
