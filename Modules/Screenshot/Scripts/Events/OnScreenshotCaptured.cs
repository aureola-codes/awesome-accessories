using Aureola.PubSub;

namespace Aureola.Screenshot
{
    public class OnScreenshotCaptured : IEvent
    {
        public readonly string Filepath;
        public OnScreenshotCaptured(string filepath)
        {
            Filepath = filepath;
        }
    }
}
