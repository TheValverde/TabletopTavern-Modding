using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using TTMod.Core;
using TTMod.Core.Config;
using TTMod.Core.Lifecycle;

namespace TTMod.Template;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
[BepInDependency(TtCore.PluginGuid, BepInDependency.DependencyFlags.HardDependency)]
public sealed class Plugin : BaseUnityPlugin
{
    public const string PluginGuid = "com.tabletop-tavern.yourname.template";
    public const string PluginName = "Template Mod";
    public const string PluginVersion = "0.1.0";

    private ManualLogSource _log = null!;
    private ConfigEntry<bool> _enabled = null!;

    private void Awake()
    {
        _log = Logger;
        _enabled = TtConfig.BindEnabled(Config);

        TtLifecycle.MainMenuEntered += OnMainMenuEntered;
        TtLifecycle.MapEntered += OnMapEntered;

        _log.LogInfo($"{PluginName} {PluginVersion} loaded.");
    }

    private void OnDestroy()
    {
        TtLifecycle.MainMenuEntered -= OnMainMenuEntered;
        TtLifecycle.MapEntered -= OnMapEntered;
    }

    private void OnMainMenuEntered()
    {
        if (!_enabled.Value)
        {
            return;
        }

        _log.LogInfo("Main menu is ready.");
    }

    private void OnMapEntered()
    {
        if (!_enabled.Value)
        {
            return;
        }

        _log.LogInfo("Map scene is active.");
    }
}
