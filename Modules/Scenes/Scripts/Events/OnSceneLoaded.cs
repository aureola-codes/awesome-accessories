using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneLoaded : IEvent
    {
        public readonly string SceneName;
        public OnSceneLoaded(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
