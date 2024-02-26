# Screenshot

The Screenshot module contains classes for capturing and managing screenshots within a Unity project.

## ScreenshotManager

The ScreenshotManager class facilitates the capture and storage of screenshots within a Unity project. It allows customization of the storage directory and includes optional debug logging. This class utilizes a coroutine to capture screenshots at the end of the current frame, ensuring that the captured image represents the fully rendered scene.

### Settings

- `_basePath` The base path where screenshots will be saved. If empty, the default path is the user's "My Pictures" folder.
- `_folder` The name of the folder within the base path where screenshots will be stored. Default is "Screenshots".
- `_debug` A boolean flag that enables debug logging when a screenshot is captured.

### Methods

- `CaptureScreenshot()` Public method that initiates the asynchronous screenshot capture process.

### Example Usages

**Capturing a Screenshot**

```csharp
public ScreenshotManager screenshotManager; // Assign in the inspector

public void TakeScreenshot() {
    screenshotManager.CaptureScreenshot();
    Debug.Log("Screenshot capture initiated.");
}
```

---

**Example:** [/Examples/ScreenshotManager](/Examples/ScreenshotManager)
