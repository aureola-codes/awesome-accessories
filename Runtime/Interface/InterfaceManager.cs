using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola.Interface
{
    public class InterfaceManager : MonoBehaviour
    {
        private static InterfaceService _instance;

        [Header("Settings")]
        [SerializeField] private EventSystem _eventSystem;

        public static InterfaceService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new InterfaceService(_eventSystem);
        }
    }
}
