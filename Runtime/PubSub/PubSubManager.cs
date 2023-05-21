using UnityEngine;

namespace Aureola.Accessories
{
    public class PubSubManager : MonoBehaviour
    {
        private static PubSubService _instance;

        [Header("Settings")]
        [SerializeField] private bool _debugging = false;

        public static PubSubService instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = new PubSubService(_debugging);
        }
    }
}
