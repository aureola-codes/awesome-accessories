using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneExiting : IEvent
    {
        public readonly string SceneName;
        public OnSceneExiting(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
