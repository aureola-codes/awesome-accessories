using Aureola.PubSub;

namespace Aureola.Loader
{
    public class LoaderProgress : IGameEvent
    {
        public float progress;
        public LoaderProgress(float progress)
        {
            this.progress = progress;
        }
    }
}
