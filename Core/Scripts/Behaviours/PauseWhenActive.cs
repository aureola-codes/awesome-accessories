using UnityEngine;

namespace Aureola
{
    public class PauseWhenActive : MonoBehaviour
    {
        private float _timeScale = 1f;

        private void OnEnable()
        {
            _timeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            Time.timeScale = _timeScale;
        }
    }
}
