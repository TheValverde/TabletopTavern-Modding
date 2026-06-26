# Template mod

Copy this folder when starting a new Tabletop Tavern BepInEx mod.

## Required dependency

Every ecosystem mod should depend on Modding Core:

```csharp
[BepInDependency(TtCore.PluginGuid, BepInDependency.DependencyFlags.HardDependency)]
```

Runtime GUID:

`com.tabletop-tavern.core`

## Standard config

Use BepInEx config so Configuration Manager can show settings in-game:

```csharp
private ConfigEntry<bool> _enabled = TtConfig.BindEnabled(Config);
```

## Lifecycle events

Use `TtLifecycle` instead of each mod polling scene state:

```csharp
TtLifecycle.MainMenuEntered += OnMainMenuEntered;
TtLifecycle.MapEntered += OnMapEntered;
```

Unsubscribe in `OnDestroy`.

## Rename checklist

- Change `RootNamespace`.
- Change `AssemblyName`.
- Change `PluginGuid`.
- Change `PluginName`.
- Change `PluginVersion`.
- Keep the dependency on `TTMod.Core`.
