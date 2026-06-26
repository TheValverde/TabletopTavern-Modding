# Getting started

This guide is for building BepInEx mods for Tabletop Tavern.

## Requirements

- .NET SDK
- Tabletop Tavern installed locally
- BepInEx Core installed for testing
- Modding Core installed for testing

Set the game path:

```powershell
$env:TT_GAME_ROOT = "C:\Program Files (x86)\Steam\steamapps\common\TabletopTavern"
```

Build Modding Core:

```powershell
dotnet build src\TTMod.Core\TTMod.Core.csproj -c Release
```

Build the template:

```powershell
dotnet build examples\TTMod.Template\TTMod.Template.csproj -c Release
```

## Create a mod

1. Copy `examples/TTMod.Template/`.
2. Rename the namespace, assembly, and plugin identifiers.
3. Keep the dependency on `TTMod.Core`.
4. Add settings with BepInEx config.
5. Use lifecycle events from `TtLifecycle`.

## Required dependency

Use this dependency for ecosystem mods:

```csharp
[BepInDependency(TtCore.PluginGuid, BepInDependency.DependencyFlags.HardDependency)]
```

Direct GUID:

```text
com.tabletop-tavern.core
```

## Settings

Use BepInEx config entries. Configuration Manager will display them automatically.

```csharp
private ConfigEntry<bool> _enabled = TtConfig.BindEnabled(Config);
```

## Lifecycle

Use core lifecycle events instead of each mod polling the game state.

```csharp
TtLifecycle.MainMenuEntered += OnMainMenuEntered;
TtLifecycle.MapEntered += OnMapEntered;
```
