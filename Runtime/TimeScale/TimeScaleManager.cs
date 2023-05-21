using UnityEngine;

namespace Aureola.Accessories
{
    public class TimeScaleManager : TimeScaleService
    {
        private static TimeScaleManager _instance;

        public static TimeScaleManager instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = this;
        }
    }
}
