![Aureola's Awesome Accessories](/Images/awesome-accessories-1024x400.png)

[![Made by Aureola](https://img.shields.io/badge/Made%20by-Aureola-ff6a00.svg)](https://aureola.codes/en/contact) [![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-brightgreen.svg)](https://github.com/aureola-codes/awesome-accessories/graphs/code-frequency) [![License](https://img.shields.io/badge/License-MIT-blue.svg)](https://en.wikipedia.org/wiki/MIT_License) [![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-57b9d3.svg?style=flat&logo=unity)](https://unity3d.com)

A Unity package containing accessories &amp; utilities that I use in all of my Unity projects.

**Important:** This project currently is a **work in progress** as new services are added or existing ones are updated. There will be breaking changes in the future! Although I will try to be as transparent as possible about these changes, things may break. Keep that in mind. My advice is to test things thoroughly when updates are made.

## Prerequisites

The following packages are required:

- [SimpleJSON for Unity](https://github.com/aureola-codes/SimpleJSON-Unity)
- [Unity Addressables](https://docs.unity3d.com/Manual/com.unity.addressables.html)
- [Unity TextMeshPro](https://docs.unity3d.com/Manual/com.unity.textmeshpro.html)

Enable the Addressables module by navigating to `Asset Management` -> `Addressables` -> `Groups` and click on `Create Addressables Settings`. This will create a new `AddressableAssetSettings` asset in your project. You can now use the module in your project.

**Note:** You need to install SimpleJSON manually using my fork.

## Installation

### Unity Package

Download the Unity Package from the last published version.

### Manually

You can also just download the source code of this package from Git and copy all or parts of it directly into your project.

## Core Concepts

In order to make this collection of utilities more accessible, I have defined some core concepts that I adhere to when developing this package.

### Managers

Managers are the core of this package. They are responsible for managing a specific problem domain, such as the `AudioManager` for handling audio playback or the `TranslationManager` for handling translations. All managers are Scriptable Objects and can be added to every behaviour in your project. You can have multiple instances of a manager, but you should only have one instance of a manager per behaviour.

### Behaviours

Behaviours are the core of Unity. They are the building blocks of every game or application. This package provides a set of behaviours that can be used to extend the functionality of Unity's built-in behaviours. For example, the `PlayGlobalSound` can be used to play audio clips in a more convenient way.

### Communication & Delegates

Managers and Behaviours communicate with each other using delegates. This allows for a more decoupled architecture and makes it easier to extend the functionality of the package.

### Services

Services are used to provide additional functionality used by certain managers or behaviours. For example, the `FilesService` is used to read and write files to the file system. You need to instantiate services manually inside the behaviour or manager that uses them.

## Modules

- [Core](/Core/README.md)
- [Audio](/Modules/Audio/README.md)
- [Config](/Modules/Config/README.md)
- [Scenes](/Modules/Scenes/README.md)
- [Screenshot](/Modules/Screenshot/README.md)
- [Settings](/Modules/Settings/README.md)
- [Translation](/Modules/Translation/README.md)
- [WebRequest](/Modules/WebRequest/README.md)

## Support the Project

If you find this project helpful and would like to contribute to its development and ongoing maintenance, your support would be greatly appreciated. By making a donation, you can help ensure the sustainability of the project and allow me to devote more time and resources to improving it.

### How can you contribute?

- **Financial contributions:** If you would like to make a monetary donation, you can do so securely through [PayPal](https://www.paypal.com/donate/?hosted_button_id=EH6AY3SNVNP86). Every contribution, no matter the amount, makes a difference and is greatly appreciated.
- **Bug Reports and Feature Requests:** If you encounter problems while using the project, or have ideas for new features, please open an issue in the GitHub repository. Your feedback and suggestions are critical to improving the project for everyone.
- **Code Contributions:** If you are a developer and would like to contribute directly to the project's codebase, feel free to submit a pull request. Contributions of all sizes are welcome and will be acknowledged.

## Your Contribution Counts, No Matter the Form

Even if you are unable to contribute financially or through code, there are other ways to show your support:

- **Star the project on GitHub.** This will help increase its visibility and attract more users.
- **Share the project with others.** Spread the word about the project and help it reach a wider audience.

Your support means a lot to me, and it motivates me to keep working on and improving this project. Thank you for considering a donation and supporting its development!

## Support

This package should work in all currently supported Unity versions. Please let me know, if you run into any compatibility issues.

## License

MIT License, Copyright (c) 2023 Christian Hanne
