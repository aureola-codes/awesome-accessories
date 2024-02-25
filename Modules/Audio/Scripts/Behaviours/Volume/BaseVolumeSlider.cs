using UnityEngine;
using UnityEngine.UI;

namespace Aureola.Audio
{
    [RequireComponent(typeof(Slider))]
    abstract public class BaseVolumeSlider : MonoBehaviour
    {
        protected Slider _slider;

        [Header("Dependencies")]
        [SerializeField] protected AudioManager _audioManager;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        protected abstract void OnValueChanged(float value);
    }
}
