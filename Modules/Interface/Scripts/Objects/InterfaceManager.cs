using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola
{
    [CreateAssetMenu(fileName = "InterfaceManager", menuName = "Aureola/Interface/InterfaceManager", order = 8)]
    public class InterfaceManager : ScriptableObject
    {
        private EventSystem _eventSystem;

        public void Register(EventSystem eventSystem)
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
