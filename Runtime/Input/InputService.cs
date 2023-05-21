using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola.Accessories
{
    public class InputService
    {
        [SerializeField] private EventSystem _eventSystem;

        public InputService(EventSystem eventSystem)
        {
            _eventSystem = eventSystem;
        }

        public void Enable()
        {
            _eventSystem.enabled = true;
        }

        public void Disable()
        {
            _eventSystem.enabled = false;
        }
    }
}
