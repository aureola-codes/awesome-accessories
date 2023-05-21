using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola.Accessories
{
    public class InputService : MonoBehaviour
    {
        [SerializeField] protected EventSystem _eventSystem;

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
