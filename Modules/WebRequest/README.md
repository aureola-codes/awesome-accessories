# WebRequest

The `WebRequest` module provides a simple way to make web requests from within your game. It is built on top of Unity's `UnityWebRequest` and `DownloadHandler` classes, and provides a simple interface for making requests and handling responses.

## WebRequestService

The WebRequestService class provides a flexible and convenient way to handle web requests within Unity applications. It supports GET, POST, and other HTTP methods, customizable timeouts, debugging options, and callbacks for success and failure scenarios.

### Configuration Methods

- `SetTimeout(int timeout)` Sets the timeout for the web request in seconds.
- `SetDebugging(bool debugging)` Enables or disables debugging logs.
- `SetSuccessCallback(Success callback)` Sets the callback function to be called upon a successful request.
- `SetFailureCallback(Failure callback)` Sets the callback function to be called upon a failed request.

### Request Methods

- `Send(WebRequestData data)` Sends a web request using the provided WebRequestData object.
- `Send(string url)` Sends a GET request to the specified URL.
- `Send(string url, WebRequestMethod method)` Sends a request to the specified URL using the given HTTP method.
- `Send(string url, WebRequestMethod method, string payload)` Sends a request with a payload to the specified URL using the given HTTP method.
- `Send(string url, WebRequestMethod method, Dictionary<string, string> headers)` Sends a request with custom headers to the specified URL using the given HTTP method.
- `Send(string url, WebRequestMethod method, Dictionary<string, string> headers, string payload)` Sends a request with a payload and custom headers to the specified URL using the given HTTP method.

### Example Usages

**Sending a Simple GET Request**

```csharp
WebRequestService webRequestService = new WebRequestService();
webRequestService.SetSuccessCallback(response => Debug.Log("Success: " + response))
                 .SetFailureCallback(error => Debug.LogError("Error: " + error))
                 .Send("http://example.com");
```

**Sending a POST Request with Payload**

```csharp
WebRequestService webRequestService = new WebRequestService().SetDebugging(true);
string payload = "{\"key\": \"value\"}";

webRequestService.SetSuccessCallback(response => Debug.Log("Success: " + response))
                 .SetFailureCallback(error => Debug.LogError("Error: " + error))
                 .Send("http://example.com/api/data", WebRequestMethod.POST, payload);
```

**Customizing Request with Headers**

```csharp
WebRequestService webRequestService = new WebRequestService();
Dictionary<string, string> headers = new Dictionary<string, string>
{
    {"Authorization", "Bearer YOUR_ACCESS_TOKEN"},
    {"Content-Type", "application/json"}
};

webRequestService.SetSuccessCallback(response => Debug.Log("Success: " + response))
                 .SetFailureCallback(error => Debug.LogError("Error: " + error))
                 .Send("http://example.com/api/data", WebRequestMethod.GET, headers);
```

**Setting a Custom Timeout**

```csharp
WebRequestService webRequestService = new WebRequestService()
    .SetTimeout(20) // Set timeout to 20 seconds
    .SetSuccessCallback(response => Debug.Log("Success: " + response))
    .SetFailureCallback(error => Debug.LogError("Error: " + error));

webRequestService.Send("http://example.com/api/long-running");
```

---

**Example:** [/Examples/WebRequestService](/Examples/WebRequestService)
