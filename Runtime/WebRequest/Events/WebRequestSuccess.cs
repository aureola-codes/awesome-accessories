using Aureola.PubSub;

namespace Aureola.WebRequest
{
    public class WebRequestSuccess : IGameEvent
    {
        public string data;
        public WebRequestSuccess(string data)
        {
            this.data = data;
        }
    }
}
