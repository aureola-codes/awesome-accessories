using UnityEngine;

namespace Aureola.Accessories
{
    public class PubSubManager : PubSubService
    {
        private static PubSubManager _instance;

        public static PubSubManager instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = this;
        }
    }
}
