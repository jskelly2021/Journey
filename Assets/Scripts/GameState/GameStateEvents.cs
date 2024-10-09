using System;

public class GameStateEvents
{
    public static event Action<GameStates> OnChangeGameState;
    
    public static void ChangeGameState(GameStates gameState) => OnChangeGameState?.Invoke(gameState);
}
