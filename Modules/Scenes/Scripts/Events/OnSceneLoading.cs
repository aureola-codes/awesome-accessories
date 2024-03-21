using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneLoading : IEvent
    {
        public readonly string SceneName;
        public OnSceneLoading(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
