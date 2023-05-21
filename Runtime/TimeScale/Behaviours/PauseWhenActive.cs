

using UnityEngine;

namespace Aureola.Accessories
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
