# Config

This service can be used to load configuration files. The files need to be in json format. Only simple key-value-maps are currently supported. The configuration manager supports the following types: float, string, int, bool, Vector2, Vector3, Vector4, Quartenion, Color, Color32.

## ConfigService

Create a new configuration service:

```
var configService = new ConfigService();
```

If you want to, you can use a custom storage service. By default the **ConfigService** will use the **RuntimeStorageService**.

```
var configService = new ConfigService(myStorageService);
```

You can use the **Load()** method to load your configuration file. The file must be an **AssetReference**.

```
configService.Load(myAssetReference);
```

Please note, that configuration are loaded additive. So new values will be added and existing ones will be overwritten. If you want to start with a clean state, you can use the **Clear()** method.

```
configService.Clear();
```

To fetch values from the **ConfigService**, you can use the **Get()** method. You will always have to define a default value for this to work. The default value must have the same type as the value you want to receive. If the configuration value is not found within the **ConfigService** the default value is returned instead.

```
configService.Get("myVector2", Vector2.Zero);
configService.Get("myBoolean", false);
configService.Get("myFloatValue", 0f);
```

You can also set configuration values using the **Set()** method:

```
configService.Set("myVector2", new Vector2(2f, 4f));
configService.Set("myBoolean", true);
configService.Set("myFloatValue", myFloat);
```

Please note, that these values by default are not stored permanently.

## ConfigManager

### Settings

- **configFile** Path to the configuration file you want to load.

### Events

Events are published in the channel **Config**.

- **ConfigLoaded** Triggered when a new configuration has been loaded.

## Dependencies

- Aureola.PubSub
- Aureola.Storage
- SimpleJSON
