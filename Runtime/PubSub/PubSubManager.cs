using UnityEngine;

namespace Aureola.PubSub
{
    public class PubSubManager : MonoBehaviour
    {
        private static PubSubService _service;

        [Header("Settings")]
        [SerializeField] private bool _debugging = false;

        public static PubSubService service
        {
            get => _service;
        }

        private void Awake()
        {
            _service = new PubSubService(_debugging);
        }
    }
}
