using UnityEngine;

namespace Aureola.TimeScale
{
    public class TimeScaleManager : MonoBehaviour
    {
        private static TimeScaleService _instance;

        public static TimeScaleService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new TimeScaleService();
        }
    }
}