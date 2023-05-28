# Loader

This service can be used, when creating any kind of loading scene. For example the main loading screen, when preparing the app, or loading screens between different scenes. It is especially handy, when you have multiple services loading stuff in the background. In this documentation I will call these services **threads**.

## LoaderService

Create a new instance of the service:

```
var loaderService = new LoaderService();
```

Register new loader threads:

```
loaderService.Add("audioFiles");
loaderService.Add("configuration");
loaderService.Add("gameData");
```

Remove a loader thread from the service:

```
loaderService.Remove("audioFiles");
```

Update the progress of a loader thread:

```
loaderService.SetProgress("configuration", 0.8f);
loaderService.SetProgress("gameData", 0.2f);
```

Get the progress of a loader thread:

```
var progress = loaderService.GetProgress("configuration");
```

Get the progress of all loader threads:

```
var totalProgress = loaderService.progress;
``` 

Complete a loader thread:

```
loaderService.Complete("configuration");
```

This is the same as:

```
loaderService.SetProgress("configuration", 1f);
```

Reset the loader service:

```
loaderService.Clear();
```

## LoaderManager

### Events

- Events are published in the channel **Loader**.
- **LoaderProgress** Triggered whenever the progress for a single loader thread changes.
- **LoaderComplete** Triggered as soon as all loader threads.