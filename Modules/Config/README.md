# Config

The config module contains everything related to configuration.

## ConfigManager

The ConfigManager class is designed to manage configuration settings for a Unity project. It loads configuration data from a specified JSON file and stores the data in a runtime cache. The class supports a variety of data types, including primitives, Vector2, Vector3, Quaternion, and Color. It also includes functionality to clear the cache and retrieve stored values.

### Settings

- `_configFile` A serialized field that holds an AssetReference to the JSON configuration file.

### Methods

- `Load()` Loads the configuration data from the _configFile.
- `Load(bool clearBeforeLoad)` Optionally clears the cache before loading the configuration data.
- `Get<T>(string key, T defaultValue)` Retrieves a value of type T from the cache, returning a default value if the key is not found.
- `Clear()` Clears all data from the cache.

### Events

- `OnLoaded` An event that is invoked when the configuration data is successfully loaded.

### Example Usages

**Loading Configuration Data**

```csharp
public ConfigManager configManager; // Assume this is already assigned through the inspector or elsewhere

void Start() {
    configManager.OnLoaded += ConfigurationLoaded;
    configManager.Load();
}

void ConfigurationLoaded() {
    Debug.Log("Configuration data loaded successfully.");
}
```

**Retrieving Configuration Values**

```csharp
void GetConfigValues() {
    var musicVolume = configManager.Get("musicVolume", 0.5f);
    var playerName = configManager.Get("playerName", "DefaultPlayer");
    var playerSpeed = configManager.Get("playerSpeed", 5);
    var backgroundColor = configManager.Get("backgroundColor", Color.white);

    Debug.Log($"Music Volume: {musicVolume}, Player Name: {playerName}, Player Speed: {playerSpeed}, Background Color: {backgroundColor}");
}
```

**Clearing Configuration Data**

```csharp
void ClearConfig() {
    configManager.Clear();
    Debug.Log("Configuration data cleared.");
}
```

**Example `config.json`**

```json
{
  "musicVolume": 0.8,
  "playerName": "Hero",
  "fullscreen": true,
  "backgroundColor": "#ff6700",
  "playerPosition": [250, 45, 20],
  "enemyColor": "rgba(255,0,0,0.5)",
  "playerSpeed": 5,
  "cameraPosition": {
    "x": 0,
    "y": 100,
    "z": -10
  },
  "spawnRate": 2.5,
  "isInvincible": false,
  "checkpoint": {
    "x": 150.5,
    "y": 75.25,
    "z": 0
  },
  "ambientLightColor": {
    "r": 255,
    "g": 255,
    "b": 255,
    "a": 90
  }
}
```

---

**Example:** [/Examples/ConfigManager](/Examples/ConfigManager)
