# Settings

The Settings module contains classes for managing user settings within a Unity project.

## SettingsManager

The SettingsManager class facilitates the management of application settings within a Unity project. It provides a structure for loading, saving, and accessing settings data through a customizable settings driver. The class raises events on key operations such as loading, saving, changes, and errors, allowing for responsive and dynamic settings management.

### Settings

- `_driver` A serialized field that holds a reference to the settings driver.

### Properties

- `IsReady` A boolean indicating whether the settings are loaded and ready to use.
- `Data` Provides access to the current SettingsData instance.

### Methods

- `Load()` Initiates the loading of settings.
- `Save()` Initiates the saving of current settings.
- `Reset()` Resets settings to their default values.
- `Set<T>(string key, T value)` Sets a value for a given setting key.
- `Get<T>(string key)` Gets the value for a given setting key.

### Events

- `OnChanged` Triggered when settings have been changed.
- `OnLoaded` Triggered after settings have been loaded successfully.
- `OnStored` Triggered after settings have been saved successfully.
- `OnError` Triggered when an error occurs during loading or saving settings.

### Example Usages

**Loading Settings**

```csharp
public SettingsManager settingsManager; // Assign in the inspector

void Start() {
    settingsManager.OnLoaded += SettingsLoaded;
    settingsManager.Load();
}

private void SettingsLoaded() {
    Debug.Log("Settings loaded successfully.");
}
```

**Saving Settings**

```csharp
public void SaveSettings() {
    settingsManager.OnStored += SettingsSaved;
    settingsManager.Save();
}

private void SettingsSaved() {
    Debug.Log("Settings saved successfully.");
}
```

**Accessing and Modifying Settings**

You can use the Get and Set methods to access and modify settings. For example, to modify a sound volume setting:

```csharp
public void UpdateSoundVolume(float volume) {
    settingsManager.Set("soundVolume", volume);
    Debug.Log("Sound volume updated.");
}
```

And to retrieve it:

```csharp
public float GetSoundVolume() {
    return settingsManager.Get("soundVolume");
}
```

**Handling Errors**

```csharp
void Start() {
    settingsManager.OnError += SettingsError;
    settingsManager.Load();
}

private void SettingsError(string message) {
    Debug.LogError("Settings error: " + message);
}
```

## SettingsData

To define your own settings, you need to utilize the SettingsData class. This is a partial class that you can extend to include your own settings fields. The following example demonstrates how the Audio module defines settings:

```csharp
public partial class SettingsData
{
    public float masterVolume = 1f;
    public float musicVolume = 0.5f;
    public float soundVolume = 0.5f;
    public float voiceVolume = 0.5f;
}
```

You can also easily add your own settings to the data class:

```csharp
public partial class SettingsData
{
    public bool showTutorial = true;
    public int difficultyLevel = 2;
    public string playerName = "Player";
}
```

## Drivers

### SimpleSettingsDriver

The SimpleSettingsDriver stores user settings utilizing Unity's PlayerPrefs system. It provides a simple and easy-to-use solution for managing settings in a Unity project.

### FileSettingsDriver

The FileSettingsDriver stores user settings in a JSON file on the file system. It provides a more flexible and customizable solution for managing user settings in a Unity project.

---

**Example:** [/Examples/SettingsManager](/Examples/SettingsManager)
