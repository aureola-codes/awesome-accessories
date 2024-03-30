using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneLoading : IPubSubEvent
    {
        public readonly string sceneName;
        public OnSceneLoading(string sceneName)
        {
            this.sceneName = sceneName;
        }
    }
}
