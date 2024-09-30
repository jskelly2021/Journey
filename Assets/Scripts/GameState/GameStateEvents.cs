using System;

public class GameStateEvents
{
    public static event Action<GameStates> OnSetGameState;
    public static void SetGameState(GameStates gameState) => OnSetGameState?.Invoke(gameState);
}
