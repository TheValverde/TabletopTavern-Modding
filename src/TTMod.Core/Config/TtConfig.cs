using BepInEx.Configuration;

namespace TTMod.Core.Config;

public static class TtConfig
{
    public const string GeneralSection = "General";
    public const string GameplaySection = "Gameplay";
    public const string UiSection = "UI";
    public const string AdvancedSection = "Advanced";

    public static ConfigEntry<bool> BindEnabled(ConfigFile config, bool defaultValue = true)
    {
        return config.Bind(
            GeneralSection,
            "Enabled",
            defaultValue,
            "Turn this mod on or off.");
    }
}
