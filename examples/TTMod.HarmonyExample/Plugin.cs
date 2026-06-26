using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using TTMod.Core;
using TTMod.Core.Config;
using TTMod.Core.Patching;
using TTMod.HarmonyExample.Patches;

namespace TTMod.HarmonyExample;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
[BepInDependency(TtCore.PluginGuid, BepInDependency.DependencyFlags.HardDependency)]
public sealed class Plugin : BaseUnityPlugin
{
    public const string PluginGuid = "com.tabletop-tavern.harmonyexample";
    public const string PluginName = "Harmony Example Mod";
    public const string PluginVersion = "0.1.1";

    internal static ManualLogSource LogSource = null!;

    private Harmony? _harmony;

    private void Awake()
    {
        LogSource = Logger;

        var enabled = TtConfig.BindEnabled(Config);
        var multiplier = Config.Bind(
            TtConfig.GameplaySection,
            "GoldGainMultiplier",
            2f,
            "Multiply positive campaign gold gains by this amount. 1 = vanilla.");
        var logGoldChanges = Config.Bind(
            TtConfig.AdvancedSection,
            "LogGoldChanges",
            true,
            "Log each GoldManager.ModifyGold call (demonstrates a Harmony Postfix).");

        GoldGainMultiplierPatch.Configure(enabled, multiplier, logGoldChanges);

        _harmony = TtHarmony.PatchAssembly(PluginGuid, typeof(Plugin).Assembly, Logger);

        LogSource.LogInfo($"{PluginName} {PluginVersion} loaded.");
        LogSource.LogInfo("Start a campaign run and earn gold to see the Prefix multiplier in action.");
        LogSource.LogInfo("Check BepInEx/LogOutput.log for Postfix log lines.");
    }

    private void OnDestroy()
    {
        _harmony?.UnpatchSelf();
    }
}
