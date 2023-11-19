using UnityEngine;

namespace Aureola.TimeScale
{
    [RequireComponent(typeof(AudioSource))]
    public class MuteOnPause : MonoBehaviour
    {
        private AudioSource _audioSource;

        [Header("Dependencies")]
        [SerializeField] private TimeScaleManager _timeScale;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _timeScale.onChanged += CheckIsPaused;
            CheckIsPaused();
        }

        private void OnDisable()
        {
            _timeScale.onChanged -= CheckIsPaused;
        }

        private void CheckIsPaused()
        {
            _audioSource.mute = _timeScale.IsPaused();
        }
    }
}
