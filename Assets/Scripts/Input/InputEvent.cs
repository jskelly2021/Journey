using System;

public class InputEvent
{
    public static event Action<GameStates> OnSetGameState;

    public static void setGameState(GameStates gameState) => OnSetGameState?.Invoke(gameState);
}
