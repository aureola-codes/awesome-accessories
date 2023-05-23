using System.Collections;
using UnityEngine;

namespace Aureola.TimeScale
{   
    public class TimeScaleService
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
    }
}
