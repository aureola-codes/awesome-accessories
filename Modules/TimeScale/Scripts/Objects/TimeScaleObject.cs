using System.Collections;
using UnityEngine;

namespace Aureola.TimeScale
{   
    [CreateAssetMenu(fileName = "TimeScale", menuName = "Aureola/Shared/TimeScale")]
    public class TimeScaleObject : ScriptableObject
    {
        public delegate void OnChanged();
        public event OnChanged onChanged;

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
            onChanged?.Invoke();
        }
    }
}
