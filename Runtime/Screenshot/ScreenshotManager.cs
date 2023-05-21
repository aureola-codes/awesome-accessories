using UnityEngine;

namespace Aureola.Accessories
{
    public class ScreenshotManager : ScreenshotService
    {
        private static ScreenshotManager _instance;

        public static ScreenshotManager instance
        {
            get => _instance;
        }

        private void Awake()
        {
            _instance = this;
        }
    }
}
