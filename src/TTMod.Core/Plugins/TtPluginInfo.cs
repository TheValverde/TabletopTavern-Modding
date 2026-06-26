namespace TTMod.Core.Plugins;

public readonly struct TtPluginInfo
{
    public TtPluginInfo(string name, string version, string guid, string location)
    {
        Name = name;
        Version = version;
        Guid = guid;
        Location = location;
    }

    public string Name { get; }
    public string Version { get; }
    public string Guid { get; }
    public string Location { get; }
}
