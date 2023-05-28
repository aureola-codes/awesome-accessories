using Aureola.PubSub;

namespace Aureola.WebRequest
{
    public class WebRequestFailure : IGameEvent
    {
        public string error;
        public WebRequestFailure(string error)
        {
            this.error = error;
        }
    }
}
