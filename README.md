# CMDGameEngine

CMDGameEngine is a simple console game engine written in C# on .NET 8.0 platform. It consists of three main components: GameObjects, GameMenu, and GameScreen, allowing you to create interactive console games.

# Installation

To use CMDGameEngine, simply add the provided DLL file to your project. No additional installations or configurations are required.
You can also add it from NuGet Manager or https://www.nuget.org/packages/CMDGameEngine.

## Installation .net cli

> dotnet add package CMDGameEngine --version 1.0.4

## Using the Engine

1. Add a reference to the engine's DLL file in your project.
2. Utilize the provided solutions by the engine such as GameObjects, GameMenu, and GameScreen to create interactive game elements in the console.

## Requirements

CMDGameEngine is developed on .NET 8.0, hence it requires .NET 8.0 runtime environment to function properly.

## Sample Game

The repository includes a sample game using CMDGameEngine. You can run it to see the capabilities of the engine.

## Visual Map xml file

Structure of Visual Map xml file for GameObjects 
```xml
<?xml version="1.0" encoding="utf-8"?>
<objectVisualMap>
  <element x="0" y="0" sign="?" />
</objectVisualMap>
```

- Txt To XML VisualMap CMDGameEngine Converter (https://github.com/radoslawsmoronski/TxtToXmlVisualMapCMDGameEngineConverter).

## Author

- Radosław Smoroński
- Contact: radoslaw.smoronski@gmail.com

## License

This project is licensed under the MIT License. Details can be found in the LICENSE file.
