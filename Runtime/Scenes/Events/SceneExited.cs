using Aureola.PubSub;

namespace Aureola.Scenes
{
    public class SceneExited : IGameEvent
    {
        public string sceneName;
        public SceneExited(string sceneName)
        {
            this.sceneName = sceneName;
        }
    }
}
