using Aureola.PubSub;

namespace Aureola.Screenshot
{
    public class OnScreenshotCaptured : IPubSubEvent
    {
        public readonly string Filepath;
        public OnScreenshotCaptured(string filepath)
        {
            Filepath = filepath;
        }
    }
}
