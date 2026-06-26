using BepInEx.Configuration;
using HarmonyLib;
using TJ;

namespace TTMod.HarmonyExample.Patches;

/// <summary>
/// Example Harmony patch for <see cref="GoldManager.ModifyGold"/>.
/// Target assembly: TabletopTavern.Core.dll (namespace TJ).
/// </summary>
[HarmonyPatch(typeof(GoldManager), nameof(GoldManager.ModifyGold))]
internal static class GoldGainMultiplierPatch
{
    private static ConfigEntry<bool> _enabled = null!;
    private static ConfigEntry<float> _multiplier = null!;
    private static ConfigEntry<bool> _logChanges = null!;

    internal static void Configure(
        ConfigEntry<bool> enabled,
        ConfigEntry<float> multiplier,
        ConfigEntry<bool> logChanges)
    {
        _enabled = enabled;
        _multiplier = multiplier;
        _logChanges = logChanges;
    }

    /// <summary>
    /// Prefix runs before the original method. Use ref parameters to change inputs.
    /// __state passes the vanilla amount through to the Postfix.
    /// </summary>
    [HarmonyPrefix]
    private static void Prefix(ref int amount, ref int __state)
    {
        __state = amount;

        if (!_enabled.Value || amount <= 0)
        {
            return;
        }

        amount = (int)System.Math.Round(amount * _multiplier.Value, System.MidpointRounding.AwayFromZero);
    }

    /// <summary>
    /// Postfix runs after the original method. Parameter names must match the game method exactly.
    /// </summary>
    [HarmonyPostfix]
    private static void Postfix(int amount, string localizedString, bool silent, int __state)
    {
        if (!_enabled.Value || !_logChanges.Value || __state == 0)
        {
            return;
        }

        var changed = amount != __state;
        Plugin.LogSource.LogInfo(
            $"[Harmony Postfix] GoldManager.ModifyGold vanilla={__state} applied={amount} changed={changed} reason=\"{localizedString}\" silent={silent}");
    }
}
