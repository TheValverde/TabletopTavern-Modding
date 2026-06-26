using BepInEx;

namespace TTMod.Core.Runtime;

public static class TtPaths
{
    public static string GameRoot => Paths.GameRootPath;
    public static string BepInExRoot => Paths.BepInExRootPath;
    public static string PluginRoot => Paths.PluginPath;
    public static string ConfigRoot => Paths.ConfigPath;
    public static string ManagedAssemblies => Paths.ManagedPath;
}
