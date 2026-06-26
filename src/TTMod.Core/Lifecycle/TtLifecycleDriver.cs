using Memori.Scenes;
using UnityEngine;
using MemoriSingleton = Memori.Utilities.Singleton<Memori.Scenes.SceneHandler>;

namespace TTMod.Core.Lifecycle;

internal sealed class TtLifecycleDriver : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!MemoriSingleton.HasInstance)
        {
            return;
        }

        TtLifecycle.Publish(Convert(MemoriSingleton.Instance.CurrentGameState));
    }

    private static TtGameState Convert(GameStateEnum gameState)
    {
        switch (gameState)
        {
            case GameStateEnum.Load:
                return TtGameState.Load;
            case GameStateEnum.MainMenu:
                return TtGameState.MainMenu;
            case GameStateEnum.Map:
                return TtGameState.Map;
            case GameStateEnum.Battle:
                return TtGameState.Battle;
            default:
                return TtGameState.Unknown;
        }
    }
}
