# JevIntroSkip

Studio logos and cinematics hold up every launch, and new character has to sit through the lore text and long Valkyrie flight before it can move. This mod skips all of it.

## Features

- Skips the Coffee Stain and Iron Gate logos.
- Skips the intro cinematic video before the main menu.
- Skips the lore text when a new character enters a world.
- Skips the Valkyrie flight and drops you at the start point.
- Each skip has its own setting.

## Configuration

The settings are in `BepInEx/config/JevMods.JevIntroSkip.cfg`, created on first launch.

- `Startup.SkipLogos`: skips the Coffee Stain and Iron Gate logos (default true).
- `Startup.SkipCinematic`: skips the intro cinematic video shown before the main menu (default true).
- `NewWorld.SkipLoreText`: skips the lore text a new character sees (default true).
- `NewWorld.SkipValkyrieFlight`: skips the Valkyrie flight and spawns you at the start point (default true).

## Feedback

Found a bug or have an idea for a change? Open an issue on the [GitHub issues page](https://github.com/JevMods/JevIntroSkip/issues). Refactoring suggestions are welcome too. I'll go through everything as fast as I can.

## Building from source

To build you need Windows, the .NET SDK 8 or newer (with the .NET Framework 4.8 developer pack), Valheim and BepInEx. The easiest way to get BepInEx is to install BepInExPack_Valheim in a Thunderstore Mod Manager profile.

```
git clone https://github.com/JevMods/JevIntroSkip.git
cd JevIntroSkip
dotnet build src/JevIntroSkip -c Release
```

Then copy `src/JevIntroSkip/bin/Release/JevIntroSkip.dll` into `BepInEx/plugins`.

The build looks for Valheim through Steam and for BepInEx in the Default profile of the Thunderstore Mod Manager. If yours live elsewhere, pass the paths:

```
dotnet build src/JevIntroSkip -c Release -p:ValheimDir="D:\Games\Valheim" -p:BepInExDir="D:\Games\Valheim\BepInEx"
```

You can also set the `VALHEIM_INSTALL` environment variable. With no Valheim install at all, point `ManagedDir` at the `valheim_server_Data/Managed` folder of the free Valheim Dedicated Server (Steam app 896660). The GitHub workflow does exactly that.

## Notes

- Client-side: only the player who wants the skips needs to install it.
- Source: https://github.com/JevMods/JevIntroSkip
