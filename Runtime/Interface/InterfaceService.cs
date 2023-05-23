using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola.Interface
{
    public class InterfaceService
    {
        [SerializeField] private EventSystem _eventSystem;

        public InterfaceService(EventSystem eventSystem)
        {
            _eventSystem = eventSystem;
        }

        public void EnableInput()
        {
            _eventSystem.enabled = true;
        }

        public void DisableInput()
        {
            _eventSystem.enabled = false;
        }
    }
}
