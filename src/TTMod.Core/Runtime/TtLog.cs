using BepInEx.Logging;

namespace TTMod.Core.Runtime;

public static class TtLog
{
    private static ManualLogSource? _logger;

    internal static void Initialize(ManualLogSource logger)
    {
        _logger = logger;
    }

    public static void Info(string message)
    {
        _logger?.LogInfo(message);
    }

    public static void Warning(string message)
    {
        _logger?.LogWarning(message);
    }

    public static void Error(string message)
    {
        _logger?.LogError(message);
    }
}
