using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola
{
    [CreateAssetMenu(fileName = "Interface", menuName = "Aureola/Shared/Interface")]
    public class InterfaceObject : ScriptableObject
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
