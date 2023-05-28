# Interface

This service and the available behaviours are meant to be helpers for interface related behaviours.

## InterfaceService

Create an new instance of the class:

```
var interfaceService = new InterfaceService(eventSystem);
```

Please note that the InterfaceService requires the existance of an *EventSystem*.

You can now enable or disable the input:

```
interfaceService.DisableInput();
interfaceService.EnableInput();
```

This can be useful for disabling user input during cutscenes, loading screens, or scene transitions.

## InterfaceManager

### Settings

- **eventSystem** An instance of the *EventSystem* available in the current scene.

## Behaviours

### ClickableButton

This is a base class for clickable buttons. This behaviour introduces a sound effect and a small visual effect, when clicking on the button. You will normally not use this behaviour directly and instead extend the ClickableButton class. The behaviour uses the **AudioManager** to play a global sound effect.

**Settings:**

- **sound** The sound effect played, when the button is clicked.

### DigitalClock

Ever had the need to display a digital clock in the game? You can now. Requires the existance of a *TMP_Text* behaviour. Displayed time is updated every second.

**Settings:**

- **format** The format of the displayed time.

### TextAutoHeight

Automatically adjusts the height of an element according to the text it contains. This is very useful, when you dynamically load text into elements, that are managed by Unity's layout behaviours. It will make sure, that the layout takes the required height of a text field into account.

### WebsiteButton

Can be used to create a website button or link element. When clicking on the button, a website will be opened using the device's default browser.

**Settings:**

- **url** Url of the website.
