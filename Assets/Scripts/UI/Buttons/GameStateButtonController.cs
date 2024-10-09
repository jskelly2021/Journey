using UnityEngine;

public class GameStateButtonController : MonoBehaviour
{
    public void resumeGame() => GameStateEvents.ChangeGameState(GameStates.Play);
    public void pauseGame() => GameStateEvents.ChangeGameState(GameStates.Pause);
    public void quitGame() => GameStateEvents.ChangeGameState(GameStates.Quit);
}
