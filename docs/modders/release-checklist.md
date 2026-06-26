# Release checklist

Use this checklist before publishing a Tabletop Tavern gameplay mod.

## Required metadata

- Unique plugin GUID
- Clear plugin name
- Version number
- Dependency on `com.tabletop-tavern.core`
- Nexus requirement for **Tabletop Tavern - BepInEx Core**
- Nexus requirement for **Tabletop Tavern - Modding Core**

## Config

- Use BepInEx config entries for settings.
- Add clear descriptions for settings.
- Test settings through Configuration Manager.

## Package layout

Gameplay mod zips should normally contain:

```text
BepInEx/plugins/YourMod.dll
README.txt
CHANGELOG.md
```

Do not bundle:

- BepInEx Core
- Modding Core
- Configuration Manager
- Mod Menu
- Game assemblies
- Decompiled game code

## Test

- Launch the game with BepInEx.
- Confirm the mod appears in Mod Menu.
- Check `BepInEx/LogOutput.log`.
- Test with the latest Modding Core release.
- Test uninstall by removing only your mod DLL.

## Nexus wording

Use this dependency wording:

> Requires Tabletop Tavern - BepInEx Core and Tabletop Tavern - Modding Core. Configuration Manager is recommended for in-game settings.
