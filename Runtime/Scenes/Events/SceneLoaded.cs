using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class SceneLoaded : IGameEvent
    {
        public string sceneName;
        public SceneLoaded(string sceneName)
        {
            this.sceneName = sceneName;
        }
    }
}
