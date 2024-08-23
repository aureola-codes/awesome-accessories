namespace Aureola.PubSub
{
    public class GenericEvent : IPubSubEvent
    {
        public readonly string data;
        public GenericEvent(string data)
        {
            this.data = data;
        }
    }
}
