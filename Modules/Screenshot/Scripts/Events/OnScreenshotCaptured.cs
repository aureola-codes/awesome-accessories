using Aureola.PubSub;

namespace Aureola.Screenshot
{
    public class OnScreenshotCaptured : IPubSubEvent
    {
        public readonly string filepath;
        public OnScreenshotCaptured(string filepath)
        {
            this.filepath = filepath;
        }
    }
}
