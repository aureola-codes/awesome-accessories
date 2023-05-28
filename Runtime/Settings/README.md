# Settings

The **Settings** module provides a service that allows you to load and save user settings. A number of setting variables are predefined to match the most common use cases. You can however define your own settings as well. The best way to do this is to extend the SettingsData class. This way you can easily add new settings and make sure that they are saved and loaded correctly.

## SettingsService

Create a new settings service:

```
var settingsService = new SettingsService(myStorageService);
```

You will have to provide a storage service in order to save and load the settings. By default the **SettingsService** will use the **SimpleStorageService**. But you can also use another persistant storage service from the Storage module or a custom one.

Extend the SettingsData class or use the existing one:

```
public class MySettingsData : SettingsData
{
    public float myFloatValue = 0f;
    public string myStringValue = "";
    public int myIntValue = 0;
    public bool myBooleanValue = false;
}
```

It is considered good practice to provide reasonable defaults.

Now you need to register the SettingsData class:

```
settingsService.Register(new MySettingsData());
```

You can now load the settings:

```
settingsService.Load();
```

The SettingsService currently supports the following types: float, string, int, bool.

You can set variables using the corresponding Set() methods:

```
settingsService.Set("myFloatValue", myFloat);
settingsService.Set("myStringValue", myString);
settingsService.Set("myIntValue", myInt);
settingsService.Set("myBooleanValue", myBoolean);
```

You can also get variables using the corresponding Get() methods:

```
settingsService.Get("myFloatValue", 0f);
settingsService.Get("myStringValue", "");
settingsService.Get("myIntValue", 0);
settingsService.Get("myBooleanValue", false);
```

Please note that you will always have to provide a default value. If the setting is not found within the **SettingsService** the default value is returned instead. The default value must have the same type as the value you want to receive.

You can clear all settings using the **Clear()** method:

```
settingsService.Clear();
```

Settings are automatically saved using the provided storage service.

## SettingsManager

### Events

- Events are published in the channel **Settings**.
- **SettingsUpdated** Triggered when a setting has been updated.
