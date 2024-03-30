using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneLoaded : IPubSubEvent
    {
        public readonly string sceneName;
        public OnSceneLoaded(string sceneName)
        {
            this.sceneName = sceneName;
        }
    }
}
