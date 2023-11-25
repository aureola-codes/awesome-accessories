using UnityEngine;
using UnityEngine.EventSystems;

namespace Aureola.Interface
{
    [RequireComponent(typeof(EventSystem))]
    public class RegisterEventSystem : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private InterfaceManager _interfaceManager;

        private void Awake()
        {
            _interfaceManager.Register(GetComponent<EventSystem>());
        }
    }
}
