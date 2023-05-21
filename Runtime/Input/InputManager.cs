using UnityEngine;

namespace Aureola.Accessories
{
    public class InputManager : InputService
    {
        private static InputManager _instance;

        public static InputManager instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = this;
        }
    }
}
