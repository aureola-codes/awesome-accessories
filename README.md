# Aureola's Awesome Accessories

A Unity package containing accessories &amp; utilities that I use in all of my Unity projects.

**Important:** This project currently is a **work in progress** as new services are added or existing ones are updated. There will be breaking changes in the future! Although I will try to be as transparent as possible about these changes, things may break. Keep that in mind. My advice is to test things thoroughly when updates are made.

## Prerequisites

The following packages are required:

- [SimpleJSON](https://github.com/christianhanne/SimpleJSON)
- [Unity Addressables](https://docs.unity3d.com/Manual/com.unity.addressables.html)
- [Unity TextMeshPro](https://docs.unity3d.com/Manual/com.unity.textmeshpro.html)

**Note:** You need to install SimpleJSON manually using my fork.

This package should work in all currently supported Unity versions. Please let me know, if you run into any compatibility issues.

## Table of Contents

- [Audio Manager](/Runtime/Audio/)
- [Config Manager](/Runtime/Config/)
- [Interface Manager](/Runtime/Interface/)
- [Loader Manager](/Runtime/Loader/)
- [PubSub Manager](/Runtime/PubSub/)
- [Scenes Manager](/Runtime/Scenes/)
- [Screenshot Manager](/Runtime/Screenshot/)
- [Settings Manager](/Runtime/Settings/)
- [Storage Manager](/Runtime/Storage/)
- [TimeScale Manager](/Runtime/TimeScale/)
- [Translation Manager](/Runtime/Translation/)
- [Video Manager](/Runtime/Video/)
- [WebRequest Service](/Runtime/WebRequest/)

## Coding Conventions

In order to make this collection of utilities more accessible, I have defined some coding conventions that I adhere to when developing this package.

### Services

Services are the core of this collection of development utilities. They are always self-contained by design. All dependencies must be injected using the appropriate constructor. In most cases, I have provided meaningful defaults. You can use as many instances of the same service in parallel as you like.

### Managers

Managers are used to connect **services** & **behaviours** of this package in Unity. All managers are singletons by design. This means that you can only have one instance of a particular manager in your scene. All managers expose settings in the Unity editor. To find out about the available settings of a manager, please refer to the README of the respective module (or namespace).

### Behaviours

All the scripts you can use on any game object in Unity are called behaviours. They are usually used to take advantage of a single feature of a particular **service**. For example, they are used to synchronize the volume defined by the **AudioService** with other audio sources. Most behaviours depend on the existence of certain **managers**. You can find out which **managers** are required for a particular behaviour by looking at the README of the behaviour's module (or namespace).

### Communication & Events

All **services** use [delegates](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/using-delegates) to communicate changes or other service-related events to the outside world. **Managers** listen to these delegates and (if necessary) publish events using the **PubSubManager**. **Behaviours** always use the **PubSubManager** to listen for events of interest. To find out when an event is triggered, please refer to the README of the respective module (or namespace).

## Installation

### Local Package

1. Clone this repository into a folder on your computer. Alternatively you can download the zip file and unpack it.
2. Open up your Unity project.
3. Go to **Window** -> **Package Manager**.
4. In the upper left corner of the package manager, click on the plus sign.
5. Select **Add package from disk...**
6. Search for the installation folder of your package & select the **package.json**.
7. Done.

### Install via Git

1. Make sure you have properly setup Git on your computer.
2. Open up your Unity project.
3. Go to **Window** -> **Package Manager**.
4. In the upper left corner of the package manager, click on the plus sign.
5. Select **Add package from git URL...**
6. Add the **clone url** of this package.
7. Done.

### Manually

You can also just download the latest version of this package from Git and copy all or parts of it directly into your project. Please note that this method is not officially supported by me.

## Support the Project

If you find this project helpful and would like to contribute to its development and ongoing maintenance, your support would be greatly appreciated. By making a donation, you can help ensure the project's sustainability and enable me to allocate more time and resources to its improvement.

## How can you contribute?

- **Financial Contributions:** If you would like to make a monetary donation, you can do so securely through PayPal or TODO. Every contribution, no matter the amount, makes a difference and is deeply valued.
- **Bug Reports and Feature Requests:** If you encounter any issues while using the project or have ideas for new features, please open an issue on the GitHub repository. Your feedback and suggestions are crucial in improving the project for everyone.
- **Code Contributions:** If you are a developer and would like to contribute directly to the project's codebase, feel free to submit a pull request. Contributions of all sizes are welcome and will be acknowledged.

## Show your support

Even if you are unable to contribute financially or through code, there are other ways to show your support:

- Star the project on GitHub. It helps to increase its visibility and attract more users.
- Share the project with others who might find it useful. Spread the word about the project and help it reach a wider audience.

Your support means a lot to me, and it motivates me to continue working on and improving this project. Thank you for considering a donation and supporting its development!

## License

MIT License, Copyright (c) 2023 Christian Hanne
