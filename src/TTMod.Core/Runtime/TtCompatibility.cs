using UnityEngine;

namespace TTMod.Core.Runtime;

public static class TtCompatibility
{
    public static string UnityVersion => Application.unityVersion;

    public static bool IsTestedUnityVersion()
    {
        return UnityVersion.StartsWith(TtCore.TestedUnityVersionPrefix);
    }

    public static void LogEnvironment()
    {
        TtLog.Info($"Unity version: {UnityVersion}");

        if (!IsTestedUnityVersion())
        {
            TtLog.Warning(
                $"This Tabletop Tavern build uses Unity {UnityVersion}; " +
                $"the core was tested against {TtCore.TestedUnityVersionPrefix}.");
        }
    }
}
