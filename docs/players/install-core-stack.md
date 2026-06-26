# Install the core stack

Tabletop Tavern mods use a small set of shared packages.

## Install order

1. **Tabletop Tavern - BepInEx Core**
2. **Tabletop Tavern - Modding Core**
3. **Tabletop Tavern - Configuration Manager**
4. **Tabletop Tavern - Mod Menu**
5. Gameplay mods

Install each zip into the Tabletop Tavern game folder, next to `TabletopTavern.exe`.

## What each package does

| Package | Purpose |
|---------|---------|
| BepInEx Core | Loads DLL mods |
| Modding Core | Shared API required by Tabletop Tavern mods |
| Configuration Manager | Opens mod settings with F1 |
| Mod Menu | Shows loaded mods on the main menu |

## Check that it worked

Launch the game and check:

- The main menu shows **Mods active** if Mod Menu is installed.
- Pressing **F1** opens Configuration Manager.
- `BepInEx/LogOutput.log` lists `Tabletop Tavern Modding Core`.

## Installing gameplay mods

Most gameplay mods go here:

```text
BepInEx/plugins/
```

Always read the mod page requirements before installing.
