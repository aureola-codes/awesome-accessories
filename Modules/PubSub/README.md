# PubSub

The PubSub module provides a simple and efficient way to implement the publish-subscribe pattern in Unity.

## PubSubManager

The PubSubManager class implements a simple publish-subscribe system in Unity, enabling loose coupling between components. Events can be published to channels, and objects can subscribe or unsubscribe to these channels to receive events.

You can add an instance of the PubSubManager to any Manager of this package to enable event-based communication between different parts of your project. The respective Manager will then be able to publish events to the PubSubManager, and other parts of your project can subscribe to these events. Check the documentation of the respective Manager for more information on the kind of events that are available.

### Methods

- `Publish(IPubSubEvent channelEvent)` Publishes an event to the default channel.
- `Publish(string channel, IPubSubEvent channelEvent)` Publishes an event to a specified channel.
- `Subscribe(Event callback)` Subscribes to the default channel with a callback to receive events.
- `Subscribe(string channel, Event callback)` Subscribes to a specified channel with a callback to receive events.
- `Unsubscribe(Event callback)` Unsubscribes a callback from the default channel.
- `Unsubscribe(string channel, Event callback)` Unsubscribes a callback from a specified channel.
- `ClearChannel(string channel)` Clears all subscriptions from a specified channel.
- `Reset()` Clears all channels and their subscriptions.

### Example Usages

**Defining an Event**

First, define an event that implements the IPubSubEvent interface:

```csharp
namespace Aureola.PubSub
{
    public class ExampleEvent : IPubSubEvent
    {
        public string Message;

        public ExampleEvent(string message)
        {
            Message = message;
        }
    }
}
```

**Subscribing to an Event**

Subscribe to an event on a specific channel:

```csharp
public class ExampleSubscriber : MonoBehaviour
{
    public PubSubManager pubSubManager; // Assign in the inspector

    void OnEnable()
    {
        pubSubManager.Subscribe("ExampleChannel", HandleExampleEvent);
    }

    private void HandleExampleEvent(IPubSubEvent evt)
    {
        if (evt is ExampleEvent exampleEvent)
        {
            Debug.Log("Received message: " + exampleEvent.Message);
        }
    }

    void OnDisable()
    {
        pubSubManager.Unsubscribe("ExampleChannel", HandleExampleEvent);
    }
}
```

**Publishing an Event**

Publish an event to a channel, notifying all subscribers:

```csharp
public class ExamplePublisher : MonoBehaviour
{
    public PubSubManager pubSubManager; // Assign in the inspector

    public void SendMessage()
    {
        var exampleEvent = new ExampleEvent("Hello, World!");
        pubSubManager.Publish("ExampleChannel", exampleEvent);
    }
}
```

**Resetting the PubSubManager**

Reset the PubSubManager to clear all channels and subscriptions:

```csharp
public void ResetPubSubManager()
{
    pubSubManager.Reset();
}
```
