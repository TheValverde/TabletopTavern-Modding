using TTMod.Core.Lifecycle;

namespace TTMod.Core.Scenes;

public static class TtScenes
{
    public static bool IsMainMenu => TtLifecycle.IsMainMenu;
    public static bool IsMap => TtLifecycle.IsMap;
    public static bool IsBattle => TtLifecycle.IsBattle;
    public static TtGameState Current => TtLifecycle.CurrentState;
}
