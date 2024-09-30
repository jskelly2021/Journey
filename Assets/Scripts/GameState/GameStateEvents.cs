using System;

public class GameStateEvents
{
    public static event Action OnResumeGame;
    public static event Action OnPauseGame;
    public static event Action OnQuitGame;

    public static void SetGameState(GameStates gameState)
    {
        switch (gameState)
        {
            case GameStates.Play:
                OnResumeGame?.Invoke();
                break;
            case GameStates.Pause:
                OnPauseGame?.Invoke();
                break;
            case GameStates.Quit:
                OnQuitGame?.Invoke();
                break;
            default:
                break;
        }
    }
}
