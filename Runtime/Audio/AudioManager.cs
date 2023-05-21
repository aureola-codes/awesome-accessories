using UnityEngine;

namespace Aureola.Accessories
{
    public class AudioManager : AudioService
    {
        private static AudioManager _instance;

        public static AudioManager instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = this;
        }
    }
}
