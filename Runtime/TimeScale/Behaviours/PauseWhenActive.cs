

using UnityEngine;

namespace Aureola.TimeScale
{
    public class PauseWhenActive : MonoBehaviour
    {
        private void OnEnable()
        {
            TimeScaleManager.service?.Pause();
        }

        private void OnDisable()
        {
            TimeScaleManager.service?.Resume();
        }
    }
}
