# PubSub

The **PubSubService** is the core of this package. All communication between services, managers and behaviours is handled by this service. Managers can publish events on specified channels. Channels are registered automatically. Other managers and behaviours can subscribe to  channels and listen for events.

## PubSubService

Create a new instance of this service:

```
var pubSubService = new PubSubService();
```

All events must implement the **IGameEvent** interface:

```
public class CustomEvent : IGameEvent
{
    public string myVariable1;
    public string myVariable2;

    public CustomEvent(string myVariable1, string myVariable2)
    {
        this.myVariable1 = myVariable1;
        this.myVariable2 = myVariable2;
    }
}
```

Events can define whatever variable they need. The **IGameEvent** interface is only used to identify events.

You can now publish this event to a channel:

```
pubSubService.Publish("myChannel", new CustomEvent());
```

You can subscribe to this channel and listen for events:

```
pubSubService.Subscribe("myChannel", OnCustomEvent);
```

The **OnCustomEvent** method will be called whenever an event is published on the **myChannel** channel:

```
private void OnCustomEvent(IGameEvent gameEvent)
{
    var customEvent = (CustomEvent)gameEvent;
    Debug.Log(customEvent.myVariable1);
    Debug.Log(customEvent.myVariable2);
}
```

Please note, that different events can be published on the same channel. You can use the **IGameEvent** interface to identify the event type and cast it to the appropriate type.

You can unsubscribe from a channel:

```
pubSubService.Unsubscribe("myChannel", OnCustomEvent);
```

There is a helper method to subscribe only to specific events:

```
pubSubService.Subscribe("myChannel", OnCustomEvent, typeof(CustomEvent));
```

Please note that you will have to use the specified event type in the unsubscribe method as well:

```
pubSubService.Unsubscribe("myChannel", OnCustomEvent, typeof(CustomEvent));
```

You can clear a channel like so:

```
pubSubService.Clear("myChannel");
```

You can also completely reset the service:

```
pubSubService.Reset();
```

## PubSubManager

### Settings

- **debugging** Enable or disable debugging. If enabled, the manager will log all events that are published and subscribed to.

## Channel (Constants Class)

The **Channel** class contains constants for all channels that are used by the **PubSubService** and **PubSubManager**. You can use these constants to avoid typos. They also make maintenance easier and you can see all channels and their usage in one place. It is considered best practice to extend the **Channel** class and add your own constants for your channels. 
