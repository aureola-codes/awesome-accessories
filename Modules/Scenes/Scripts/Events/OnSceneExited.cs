using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneExited : IPubSubEvent
    {
        public readonly string sceneName;
        public OnSceneExited(string sceneName)
        {
            this.sceneName = sceneName;
        }
    }
}
