using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public void resumeGame() => GameStateEvents.ChangeGameState(GameStates.Play);
    public void pauseGame() => GameStateEvents.ChangeGameState(GameStates.Pause);
    public void quitGame() => GameStateEvents.ChangeGameState(GameStates.Quit);
}
