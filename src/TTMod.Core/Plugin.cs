using BepInEx;
using BepInEx.Logging;
using TTMod.Core.Lifecycle;
using TTMod.Core.Runtime;
using UnityEngine;

namespace TTMod.Core;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public sealed class Plugin : BaseUnityPlugin
{
    public const string PluginGuid = TtCore.PluginGuid;
    public const string PluginName = TtCore.PluginName;
    public const string PluginVersion = TtCore.PluginVersion;

    internal static ManualLogSource LogSource = null!;

    private void Awake()
    {
        LogSource = Logger;
        TtLog.Initialize(Logger);
        TtCompatibility.LogEnvironment();

        var lifecycleGo = new GameObject("TTModCoreLifecycle");
        lifecycleGo.hideFlags = HideFlags.HideAndDontSave;
        lifecycleGo.AddComponent<TtLifecycleDriver>();

        Logger.LogInfo($"{PluginName} {PluginVersion} loaded.");
    }
}
