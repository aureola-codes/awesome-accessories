using UnityEngine;

namespace Aureola.TimeScale
{
    [RequireComponent(typeof(AudioSource))]
    public class MuteOnPause : MonoBehaviour
    {
        private AudioSource _audioSource;

        [Header("Dependencies")]
        [SerializeField] private TimeScaleManager _timeScaleManager;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            if (_timeScaleManager == null) {
                _timeScaleManager = SOLocator.Get<TimeScaleManager>();
            }
        }

        private void OnEnable()
        {
            _timeScaleManager.onChanged += CheckIsPaused;
            CheckIsPaused();
        }

        private void OnDisable()
        {
            _timeScaleManager.onChanged -= CheckIsPaused;
        }

        private void CheckIsPaused()
        {
            _audioSource.mute = _timeScaleManager.IsPaused();
        }
    }
}
