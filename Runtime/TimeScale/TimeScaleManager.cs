using UnityEngine;

namespace Aureola.TimeScale
{
    public class TimeScaleManager : MonoBehaviour
    {
        private static TimeScaleService _service;

        public static TimeScaleService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new TimeScaleService();
        }
    }
}
