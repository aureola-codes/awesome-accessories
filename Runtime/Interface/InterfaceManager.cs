using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola.Interface
{
    public class InterfaceManager : MonoBehaviour
    {
        private static InterfaceService _service;

        [Header("Settings")]
        [SerializeField] private EventSystem _eventSystem;

        public static InterfaceService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new InterfaceService(_eventSystem);
        }
    }
}
