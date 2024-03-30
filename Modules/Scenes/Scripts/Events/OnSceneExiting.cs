using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneExiting : IPubSubEvent
    {
        public readonly string sceneName;
        public OnSceneExiting(string sceneName)
        {
            this.sceneName = sceneName;
        }
    }
}
