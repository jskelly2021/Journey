using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public void resumeGame() => GameStateEvents.SetGameState(GameStates.Play);
    public void pauseGame() => GameStateEvents.SetGameState(GameStates.Pause);
    public void quitGame() => GameStateEvents.SetGameState(GameStates.Quit);
}
