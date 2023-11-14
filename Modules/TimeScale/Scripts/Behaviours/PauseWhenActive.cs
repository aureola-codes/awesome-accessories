using UnityEngine;

namespace Aureola.TimeScale
{
    public class PauseWhenActive : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private TimeScaleObject _timeScale;

        private void OnEnable()
        {
            _timeScale.Pause();
        }

        private void OnDisable()
        {
            _timeScale.Resume();
        }
    }
}
