using System.Threading.Tasks;
using UnityEngine;

namespace Aureola.Accessories
{
    public class ScreenshotService
    {
        private string _screenshotPath;

        public ScreenshotService(string folder)
        {
            _screenshotPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + "/" + folder;
            System.IO.Directory.CreateDirectory(_screenshotPath);
        }

        public ScreenshotService(string folder, string basePath)
        {
            _screenshotPath = basePath + "/" + folder;
            System.IO.Directory.CreateDirectory(_screenshotPath);
        }
        
        public void CaptureScreenshot()
        {
            #pragma warning disable CS4014
            CaptureScreenshotAsync();
            #pragma warning restore CS4014
        }

        public async Task CaptureScreenshotAsync()
        {
            await Task.Run(() => {
                ScreenCapture.CaptureScreenshot(_screenshotPath + "/" + GetFileName());
            });
        }

        private string GetFileName()
        {
            return "screenshot-w" + Screen.width + "-h" + Screen.height + "-" + System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".png";
        }
    }
}
