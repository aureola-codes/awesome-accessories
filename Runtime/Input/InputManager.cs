using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola.Accessories
{
    public class InputManager : MonoBehaviour
    {
        private static InputService _instance;

        [Header("Settings")]
        [SerializeField] private EventSystem _eventSystem;

        public static InputService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new InputService(_eventSystem);
        }
    }
}
