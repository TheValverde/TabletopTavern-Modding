using System.Reflection;
using BepInEx.Logging;
using HarmonyLib;

namespace TTMod.Core.Patching;

public static class TtHarmony
{
    public static Harmony PatchAssembly(string pluginGuid, Assembly assembly, ManualLogSource logger)
    {
        var harmony = new Harmony(pluginGuid);
        harmony.PatchAll(assembly);
        logger.LogInfo($"Applied Harmony patches from {assembly.GetName().Name}.");
        return harmony;
    }
}
