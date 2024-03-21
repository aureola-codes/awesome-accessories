using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneExited : IEvent
    {
        public readonly string SceneName;
        public OnSceneExited(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
