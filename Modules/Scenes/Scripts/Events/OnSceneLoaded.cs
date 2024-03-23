using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneLoaded : IPubSubEvent
    {
        public readonly string SceneName;
        public OnSceneLoaded(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
