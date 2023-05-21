using System.Collections;
using UnityEngine;

namespace Aureola.Accessories
{
    public class ScreenshotService : MonoBehaviour
    {
        protected string _screenshotPath;

        [SerializeField] protected KeyCode _key;
        [SerializeField] protected string _folder = "my-folder";

        protected void Start()
        {
            _screenshotPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + "/" + _folder;
            System.IO.Directory.CreateDirectory(_screenshotPath);
        }

        protected void Update()
        {
            if (Input.GetKeyDown(_key)) {
                StartCoroutine(CaptureScreenshot());
            }
        }

        protected IEnumerator CaptureScreenshot()
        {
            yield return null;

            string directory = _screenshotPath + "/";
            string filename = "screenshot-w" + Screen.width + "-h" + Screen.height + "-" + System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".png";
            ScreenCapture.CaptureScreenshot(directory + filename);

            Debug.Log("Screenshot taken: " + directory + filename);
        }
    }
}
