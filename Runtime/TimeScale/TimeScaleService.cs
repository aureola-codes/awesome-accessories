using System.Collections;
using UnityEngine;

namespace Aureola.Accessories
{   
    public class TimeScaleService : MonoBehaviour
    {
        public void Pause()
        {
            ChangeTimeScale(0f);
        }

        public void Resume()
        {
            ChangeTimeScale(1f);
        }

        public bool IsPaused()
        {
            return Time.timeScale == 0f;
        }

        public void ChangeTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }

        public void ChangeTimeScale(float timeScale, float duration = 5f)
        {
            Time.timeScale = timeScale;

            StopAllCoroutines();
            StartCoroutine(RevertTimeScale(duration));
        }

        protected IEnumerator RevertTimeScale(float duration)
        {
            yield return new WaitForSeconds(duration);
            Time.timeScale = 1f;
        }
    }
}
