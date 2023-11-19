# WebRequest

This module provides a service that allows you to send web requests. The corresponding manager can be used to send web requests from a behaviour or script. The WebRequestService assumes that you are trying to communicate with a text based API.

## WebRequestService

Create a new web request service:

```
var webRequestService = new WebRequestService();
```

You can now send a web request:

```
webRequestService.Send("https://myapi.com");
```

You can also send a web request with a custom method:

```
webRequestService.Send("https://myapi.com", WebRequestMethod.POST);
```

You can also send a web request with a custom method and a custom body:

```
webRequestService.Send("https://myapi.com", WebRequestMethod.POST, "my body");
```

You can also send a web request with a custom method, a custom body and custom headers:

```
var headers = new Dictionary<string, string>();
headers.Add("Content-Type", "application/json");
webRequestService.Send("https://myapi.com", WebRequestMethod.POST, "my body", headers);
```

The web request services exposes two events that you can listen to:

```
webRequestService.OnSuccess += OnSuccess;
webRequestService.OnError += OnError;
```

By listening to these events, you can react to the result of the web request:

```
private void OnSuccess(string response) {
  // Do stuff...
}

private void OnError(string error) {
  // Do stuff...
}
```

## WebRequestManager

### Events

- Events are published in the channel **WebRequest**.
- **WebRequestSuccess** is published when a web request was successful.
- **WebRequestFailure** is published when a web request failed.
