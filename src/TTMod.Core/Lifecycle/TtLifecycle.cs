using System;

namespace TTMod.Core.Lifecycle;

public static class TtLifecycle
{
    private static bool _initialized;
    private static TtGameState _currentState = TtGameState.Unknown;

    public static event Action<TtGameState>? GameStateChanged;
    public static event Action? MainMenuEntered;
    public static event Action? MapEntered;
    public static event Action? BattleEntered;

    public static bool IsReady => _initialized;
    public static TtGameState CurrentState => _currentState;
    public static bool IsMainMenu => _currentState == TtGameState.MainMenu;
    public static bool IsMap => _currentState == TtGameState.Map;
    public static bool IsBattle => _currentState == TtGameState.Battle;

    internal static void Publish(TtGameState state)
    {
        if (_initialized && _currentState == state)
        {
            return;
        }

        _initialized = true;
        _currentState = state;
        GameStateChanged?.Invoke(state);

        switch (state)
        {
            case TtGameState.MainMenu:
                MainMenuEntered?.Invoke();
                break;
            case TtGameState.Map:
                MapEntered?.Invoke();
                break;
            case TtGameState.Battle:
                BattleEntered?.Invoke();
                break;
        }
    }
}
