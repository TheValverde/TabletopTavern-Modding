using System.Collections.Generic;
using System.Linq;
using BepInEx.Bootstrap;

namespace TTMod.Core.Plugins;

public static class TtPluginRegistry
{
    public static IReadOnlyList<TtPluginInfo> GetLoadedPlugins()
    {
        return Chainloader.PluginInfos.Values
            .Select(info => new TtPluginInfo(
                info.Metadata.Name,
                info.Metadata.Version.ToString(),
                info.Metadata.GUID,
                info.Location))
            .OrderBy(entry => entry.Name)
            .ToList();
    }

    public static bool IsLoaded(string pluginGuid)
    {
        return Chainloader.PluginInfos.ContainsKey(pluginGuid);
    }
}
