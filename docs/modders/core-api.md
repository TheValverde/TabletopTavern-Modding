# Core API

Modding Core exposes a small shared API for Tabletop Tavern mods.

## Constants

```csharp
TtCore.PluginGuid
TtCore.PluginName
TtCore.PluginVersion
```

## Lifecycle

Namespace:

```csharp
using TTMod.Core.Lifecycle;
```

Events:

```csharp
TtLifecycle.GameStateChanged
TtLifecycle.MainMenuEntered
TtLifecycle.MapEntered
TtLifecycle.BattleEntered
```

State helpers:

```csharp
TtLifecycle.IsReady
TtLifecycle.CurrentState
TtLifecycle.IsMainMenu
TtLifecycle.IsMap
TtLifecycle.IsBattle
```

## Scenes

Namespace:

```csharp
using TTMod.Core.Scenes;
```

Helpers:

```csharp
TtScenes.Current
TtScenes.IsMainMenu
TtScenes.IsMap
TtScenes.IsBattle
```

## Plugins

Namespace:

```csharp
using TTMod.Core.Plugins;
```

Helpers:

```csharp
TtPluginRegistry.GetLoadedPlugins()
TtPluginRegistry.IsLoaded("plugin.guid")
```

## Paths

Namespace:

```csharp
using TTMod.Core.Runtime;
```

Paths:

```csharp
TtPaths.GameRoot
TtPaths.BepInExRoot
TtPaths.PluginRoot
TtPaths.ConfigRoot
TtPaths.ManagedAssemblies
```

## Config

Namespace:

```csharp
using TTMod.Core.Config;
```

Common sections:

```csharp
TtConfig.GeneralSection
TtConfig.GameplaySection
TtConfig.UiSection
TtConfig.AdvancedSection
```

Enabled toggle:

```csharp
var enabled = TtConfig.BindEnabled(Config);
```

## Harmony

Namespace:

```csharp
using TTMod.Core.Patching;
```

Patch helper:

```csharp
TtHarmony.PatchAssembly(PluginGuid, typeof(Plugin).Assembly, Logger);
```

Example patch class:

```csharp
[HarmonyPatch(typeof(GoldManager), nameof(GoldManager.ModifyGold))]
internal static class GoldGainMultiplierPatch
{
    [HarmonyPrefix]
    private static void Prefix(ref int amount)
    {
        if (amount > 0)
        {
            amount *= 2;
        }
    }

    [HarmonyPostfix]
    private static void Postfix(int amount, string localizedString)
    {
        if (amount > 0)
        {
            Logger.LogInfo($"ModifyGold: {amount} ({localizedString})");
        }
    }
}
```

`GoldManager` lives in namespace `TJ` inside `TabletopTavern.Core.dll`. See `examples/TTMod.HarmonyExample/` for the full buildable example with config, logging, and `__state` passing between Prefix and Postfix.
