# Harmony Example Mod

Reference mod that demonstrates **Harmony patches against real Tabletop Tavern game code**.

Copy `TTMod.Template/` when starting a blank mod. Use this example when you need to see Prefix/Postfix patching in action.

## What it demonstrates

| Concept | Where |
|---------|-------|
| Patch a game method | `Patches/GoldGainMultiplierPatch.cs` patches `TJ.GoldManager.ModifyGold` |
| Harmony Prefix | Changes `amount` before the original method runs |
| Harmony Postfix | Logs vanilla vs applied gold to `BepInEx/LogOutput.log` |
| Apply patches | `TtHarmony.PatchAssembly(...)` in `Plugin.cs` |
| Config + F1 UI | BepInEx config entries via Modding Core conventions |

## Patch target

```text
Assembly: TabletopTavern.Core.dll
Type:     TJ.GoldManager
Method:   ModifyGold(int amount, string localizedString, bool silent)
```

Harmony Postfix parameter names must match the decompiled method exactly. Using `reason` instead of `localizedString` will fail at startup.

## Build

Requires BepInEx Core and Modding Core deployed to your game folder first.

```powershell
$env:TT_GAME_ROOT = "D:\Overflow Programs\Steam\steamapps\common\TabletopTavern"
dotnet build src\TTMod.Core\TTMod.Core.csproj -c Release
dotnet build examples\TTMod.HarmonyExample\TTMod.HarmonyExample.csproj -c Release
```

The example copies itself to `BepInEx/plugins/` when that folder exists.

## Test in-game

1. Start or load a campaign run.
2. Trigger a gold change (battle reward, event, or Cheat Manager add-gold).
3. With default settings, positive gains are doubled.
4. Press **F1** to change `GoldGainMultiplier` or disable the mod.
5. Check `BepInEx/LogOutput.log` for lines like:
   `[Harmony Postfix] GoldManager.ModifyGold vanilla=500 applied=1000 changed=True ...`

## Copy this pattern

1. Copy `examples/TTMod.Template/` for a new mod, or fork this example.
2. Replace the patch class with your target type and method from dnSpy/ILSpy.
3. Keep one `TtHarmony.PatchAssembly(...)` call in `Awake()`.
4. Call `_harmony?.UnpatchSelf()` in `OnDestroy()`.

## Plugin identity

| Field | Value |
|-------|-------|
| GUID | `com.tabletop-tavern.harmonyexample` |
| DLL | `TTMod.HarmonyExample.dll` |
