# Translations

The Translations module provides a simple way to manage translations for your game.

## TranslationManager

The TranslationsManager class is designed to facilitate the management of translations within a Unity application, providing the infrastructure to support multiple languages. It allows for dynamic language switching, supports the retrieval of translated strings, and manages the active translation set.

### Settings

- `_translations` A list of all available Translation objects that the manager can handle. (see `Translation`)

### Methods

- `Get(string key)` Retrieves the translated string for the given key from the current active translation.
- `Get(string key, Dictionary<string, string> replacements)` Retrieves the translated string for the given key and replaces placeholders within the string based on the provided dictionary.
- `GetDefault()` Returns the default language as a SystemLanguage.
- `GetCode()` Returns the language code of the current active translation.
- `GetLanguage()` Returns the current active language as a SystemLanguage.
- `GetLanguageByCode(string code)` Returns the SystemLanguage corresponding to the given language code.
- `GetCodeByLanguage(SystemLanguage systemLanguage)` Returns the language code corresponding to the given SystemLanguage.
- `GetLanguageOptions()` Returns a dictionary of language codes and their labels.
- `IsSupported(SystemLanguage systemLanguage)` Checks if the given SystemLanguage is supported.
- `IsSupported(string code)` Checks if the given language code is supported.
- `SetLanguage(SystemLanguage systemLanguage)` Sets the active language to the given SystemLanguage.
- `SetLanguage(string languageCode)` Sets the active language to the one corresponding to the given language code.
- `GetTranslation(SystemLanguage systemLanguage)` Retrieves the Translation object for the specified SystemLanguage.
- `GetTranslation(string code)` Retrieves the Translation object for the specified language code.
- `Reset()` Resets the TranslationManager.

### Delegates

- `OnChanged` Triggered when the active translation changes.

### Events (PubSubManager)

- `OnLanguageChanged` Triggered when the active language changes.

### Example Usages

**Setting the Language**

To set the language to French, assuming it's supported:

```csharp
public TranslationsManager translationsManager; // Assign in the inspector

void Start() {
    translationsManager.SetLanguage(SystemLanguage.French);
}
```

**Retrieving a Translated String**

To get a translated string by its key:

```csharp
string helloText = translationsManager.Get("hello_key");
Debug.Log(helloText); // Outputs the translated "Hello" based on the active language
```

**Handling Language Change**

To react to a language change within your application:

```csharp
void OnEnable() {
    translationsManager.OnChanged += LanguageChanged;
}

void LanguageChanged(Translation translation) {
    Debug.Log("Language changed to: " + translation.Language);
    // Update UI elements or other necessary components with new language
}

void OnDisable() {
    translationsManager.OnChanged -= LanguageChanged;
}
```

**Checking If a Language Is Supported**

Before attempting to set the language, check if it's supported:

```csharp
if (translationsManager.IsSupported(SystemLanguage.German)) {
    translationsManager.SetLanguage(SystemLanguage.German);
} else {
    Debug.Log("German language is not supported.");
}
```

## Translation

The Translation class represents a single language's translation resources within a Unity application. It supports loading translation data from various sources, handling the data dynamically at runtime. This class allows for the seamless integration of multi-language support, facilitating the localization process.

### Settings 

- `_code` The language code (e.g., "en", "fr").
- `_label` The language label (e.g., "English", "Français").
- `_systemLanguage` The corresponding SystemLanguage enum value.
- `_languageFiles` A list of LanguageFile structures representing the assets to load.

### Methods

- `Load()` Initiates the loading process for all language files associated with this translation.
- `Get(string key)` Retrieves the translated string for the given key. If the translation is not loaded or the key is not found, it returns the key itself.
- `Get(string key, Dictionary<string, string> replacements)` Similar to Get(string key), but also replaces placeholders in the translated string with values from the replacements dictionary.
- `Reset()` Clears the loaded translations and resets the load state.

### Delegates

- `OnLoaded` Triggered when all translation data for the language has been successfully loaded.
- `OnError` Triggered when there is an error loading the translation data.

### Usage

Create a new Translation asset through the Unity Editor by right-clicking in the Project panel, navigating to Create -> Aureola/Translations/Translation, and then setting the properties in the Inspector panel. You can then add LanguageFile assets to the `_languageFiles` list to load the translation data from various sources. The TranslationManager will handle the loading and management of these Translation assets.

## Behaviours

- **LanguageButton** A simple button that allows the user to change the active language when clicked.
- **SystemLanguageButton** A button that sets the active language to the corresponding SystemLanguage enum value when clicked. 
- **TextMeshProTranslatable** A TextMeshPro component that automatically updates its text based on the active language and the provided key.
- **TextTranslatable** A Text component that automatically updates its text based on the active language and the provided key.

---

**Example:** [/Examples/TranslationManager](/Examples/TranslationManager)
