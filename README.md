# Tabletop Tavern Modding

Community modding foundation for Tabletop Tavern.

This repository provides the shared BepInEx core used by Tabletop Tavern mods, a starter template, and documentation for players and mod authors.

## Install order for players

1. Install **Tabletop Tavern - BepInEx Core**.
2. Install **Tabletop Tavern - Modding Core**.
3. Install **Tabletop Tavern - Configuration Manager**.
4. Install **Tabletop Tavern - Mod Menu** if you want an in-game loaded mod list.
5. Install gameplay mods.

## Projects

| Path | Purpose |
|------|---------|
| `src/TTMod.Core/` | Shared runtime and API layer for Tabletop Tavern mods |
| `examples/TTMod.Template/` | Starter BepInEx mod that depends on Modding Core |
| `examples/TTMod.ModMenu/` | Reference notes for the optional in-game mod menu |
| `docs/` | Player and mod author documentation |

## Runtime identifiers

| Package | GUID | DLL |
|---------|------|-----|
| Modding Core | `com.tabletop-tavern.core` | `TTMod.Core.dll` |
| Mod Menu | `com.tabletop-tavern.modmenu` | `TTMod.ModMenu.dll` |

## Build requirements

- .NET SDK that can build `net472`
- Tabletop Tavern installed locally
- BepInEx 5 for local testing

Set the game path before building:

```powershell
$env:TT_GAME_ROOT = "C:\Program Files (x86)\Steam\steamapps\common\TabletopTavern"
dotnet build src\TTMod.Core\TTMod.Core.csproj -c Release
```

## First mod

Copy `examples/TTMod.Template/` and rename:

- `RootNamespace`
- `AssemblyName`
- `PluginGuid`
- `PluginName`
- `PluginVersion`

Keep the dependency on `com.tabletop-tavern.core`.

## Documentation

Start here:

- `docs/index.md`
- `docs/players/install-core-stack.md`
- `docs/modders/getting-started.md`
- `docs/modders/core-api.md`

## Disclaimer

This project is not affiliated with Memori Studios, Frostbloom, or Gamirror Games.
