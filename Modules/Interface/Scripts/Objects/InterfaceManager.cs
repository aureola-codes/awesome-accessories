using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola.Interface
{
    [CreateAssetMenu(fileName = "InterfaceManager", menuName = "Aureola/Interface/InterfaceManager", order = 8)]
    public class InterfaceManager : ScriptableObject, IResettable
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

        public void Reset()
        {
            _eventSystem = null;
        }
    }
}
