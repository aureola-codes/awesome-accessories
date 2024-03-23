using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneLoading : IPubSubEvent
    {
        public readonly string SceneName;
        public OnSceneLoading(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
