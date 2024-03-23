using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class OnSceneExiting : IPubSubEvent
    {
        public readonly string SceneName;
        public OnSceneExiting(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
