# Mod Menu reference

The Mod Menu is a useful reference mod because it shows how a real plugin depends on Modding Core without becoming the core API itself.

Runtime GUID:

`com.tabletop-tavern.modmenu`

Dependency:

```csharp
[BepInDependency(TtCore.PluginGuid, BepInDependency.DependencyFlags.HardDependency)]
```

Patterns worth copying:

- Keep the plugin entry point small.
- Put Unity UI code in separate classes.
- Use `TtLifecycle` to react to game state.
- Use `TtPluginRegistry` to read loaded plugin metadata.
- Keep player-facing UI separate from shared API code.

Patterns to avoid:

- Do not make gameplay mods depend on Mod Menu unless they directly integrate with its UI.
- Do not put one-off gameplay logic into Modding Core.
- Do not bundle BepInEx with individual gameplay mods.

Recommended dependency for most gameplay mods:

```csharp
[BepInDependency("com.tabletop-tavern.core", BepInDependency.DependencyFlags.HardDependency)]
```
