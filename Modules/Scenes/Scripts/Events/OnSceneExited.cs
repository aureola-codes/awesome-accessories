using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneExited : IPubSubEvent
    {
        public readonly string SceneName;
        public OnSceneExited(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
