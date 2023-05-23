

using UnityEngine;

namespace Aureola.TimeScale
{
    public class PauseWhenActive : MonoBehaviour
    {
        private void OnEnable()
        {
            TimeScaleManager.instance?.Pause();
        }

        private void OnDisable()
        {
            TimeScaleManager.instance?.Resume();
        }
    }
}
