using UnityEngine;

namespace Aureola.Screenshot
{
    public class ScreenshotController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private KeyCode _key = KeyCode.F12;

        [Header("Dependencies")]
        [SerializeField] private ScreenshotManager _screenshotManager;

        private void Update()
        {
            if (Input.GetKeyDown(_key)) {
                _screenshotManager.CaptureScreenshot();
            }
        }
    }
}
