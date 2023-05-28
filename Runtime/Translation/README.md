# Translation

This module provides a service for translating strings in your application. You can register different languages and switch between them. Translation strings are stored using JSON and CSV files. The service will automatically load the correct file for the respective language. Behaviours will then for example automatically translate text fields using the service.

## TranslationService

Create a new instance of the translation service. Translation files are loaded using addressable assets. Therefore you need to provide the base address of the translation files. This can be the folder were all the files are stored. The service will try to load the respective translation file using it's addressable name. The addressable name must be the same as the language code you define, when registering a language.

```
var translationService = new TranslationService(baseAddress);
```

Register new languages:

```
translationService.RegisterLanguage("en", SystemLanguage.English);
translationService.RegisterLanguage("de", SystemLanguage.German);
```

You can now switch to a certain language:

```
translationService.ChangeLanguage("en");
```

The following translation files would be loaded:

```
/your/base/path/en
```

The translation service will try to guess, if the file is in JSON or CSV format. Only simple key-value-maps are supported.

You can get a translation string by using the **Get()** method:

```
translationService.Get("myKey");
```

If the translation string is not found, the key will be returned and an error will be logged.

Translation strings can contain variables. You can pass these variables to the **Get()** method:

```
var variables = new Dictionary<string, string>();
variables.Add("username", "Alfred");
translationService.Get("welcome", variables);
```

Given the translation string is defined as this:

```
{
    "welcome": "Welcome :username!"
}
```

The following string will be returned:

```
"Welcome Alfred!"
```

You can also get the current language:

```
var currentLanguage = translationService.language;
```

You can check if a certain language is registered:

```
var isRegistered = translationService.IsRegistered("en");
var isRegistered = translationService.IsRegistered(SystemLanguage.English);
```

## TranslationManager

### Settings

- **baseAddress** The base address of the translation files.
- **defaultLanguage** The default language that should be used, if no language is set.
- **languages** A list of languages that should be registered on startup.

### Events

- Events are published in the channel **Translation**.
- **LanguageChanged** This event is invoked, when the language is changed.

## Behaviours

### TextTranslatable

This behaviour can be used to translate a default Unity UI text field. The behaviour can be configured to automatically translate the text field, when the language is changed. By default it will just translate the text field once, when the behaviour is started. The translation key is the value of the textfield itself.

**Settings:**

- **autoUpdate** If this is set to true, the text field will be updated, when the language is changed.

### TextMeshProTranslatable

This behaviour can be used to translate a TextMeshPro text field. The behaviour can be configured to automatically translate the text field, when the language is changed. By default it will just translate the text field once, when the behaviour is started. The translation key is the value of the textfield itself.

**Settings:**

- **autoUpdate** If this is set to true, the text field will be updated, when the language is changed.
