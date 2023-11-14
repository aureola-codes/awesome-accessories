using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aureola.Screenshot
{
    [CreateAssetMenu(fileName = "Screenshot", menuName = "Aureola/Shared/Screenshot")]
    public class ScreenshotObject : ScriptableObject
    {
        [Header("Settings")]
        [SerializeField] private string _basePath = "";
        [SerializeField] private string _folder = "Screenshots";
        
        public void CaptureScreenshot()
        {
            Coworker.Instance.StartCoroutine(CaptureScreenshotAsync());
        }

        private IEnumerator CaptureScreenshotAsync()
        {
            yield return new WaitForEndOfFrame();

            PrepareDirectory();
            ScreenCapture.CaptureScreenshot(GetFolderPath() + "/" + GetFileName());
        }

        private string GetFolderPath()
        {
            if (_basePath == "") {
                return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + "/" + _folder;
            }

            return _basePath + "/" + _folder;
        }

        private string GetFileName()
        {
            return "screenshot-w" + Screen.width + "-h" + Screen.height + "-" + System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".png";
        }

        private void PrepareDirectory()
        {
            if (!CheckDirectory()) {
                CreateDirectory();
            }
        }

        private bool CheckDirectory()
        {
            return System.IO.Directory.Exists(GetFolderPath());
        }

        private void CreateDirectory()
        {
            System.IO.Directory.CreateDirectory(GetFolderPath());
        }
    }
}