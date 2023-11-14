# Screenshot

The **Screenshot** module provides a service that allows you to take screenshots of your game. The corresponding manager can be used to take screenshots by pressing a key or automatically in a specified interval. This can be really helpful, if you want to create screenshots while playing your game. This way the screenshots will more naturally represent the actual gameplay.

## ScreenshotService

Create a new screenshot service:

```
var screenshotService = new ScreenshotService(myStorageFolder);
```

By default all screenshots will be placed in the MyPictures folder of your system. The myStorageFolder is relative to this folder. You can however define a custom base folder:

```
var screenshotService = new ScreenshotService(myStorageFolder, myBaseFolder);
```

You can now take a screenshot:

```
screenshotService.CaptureScreenshot();
```

## ScreenshotManager

### Settings

- **key** The key that needs to be pressed to take a screenshot.
- **folder** The folder where the screenshots will be stored.
- **automated** If true, screenshots will be taken automatically in the specified interval.
- **automatedInterval** The interval in seconds in which screenshots will be taken.
