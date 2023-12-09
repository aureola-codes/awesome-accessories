using UnityEngine;

namespace Aureola.TimeScale
{
    public class PauseWhenActive : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TimeScaleManager _timeScaleManager;

        private void Awake()
        {
            if (_timeScaleManager == null) {
                _timeScaleManager = SOLocator.Get<TimeScaleManager>();
            }
        }

        private void OnEnable()
        {
            _timeScaleManager.Pause();
        }

        private void OnDisable()
        {
            _timeScaleManager.Resume();
        }
    }
}
