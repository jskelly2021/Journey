using UnityEngine;

public sealed class GameStateManager : MonoBehaviour
{
    private static GameStateManager instance = null;
    private SceneLoader sceneLoader;

    public GameStateManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    private void OnEnable()
    {
        GameStateEvents.OnSetGameState += handleGameState;
    }
    private void OnDisable()
    {
        GameStateEvents.OnSetGameState -= handleGameState;
    }

    private void resumeGame()
    {
        Time.timeScale = 1.0f;
    }

    private void pauseGame()
    {
        Time.timeScale = 0.0f;
    }

    private void quitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    private void handleGameState(GameStates gameState)
    {
        switch (gameState)
        {
            case GameStates.Play:
                resumeGame();
                break;
            case GameStates.Pause:
                pauseGame();
                break;
            case GameStates.Quit:
                quitGame();
                break;
            default:
                break;
        }
    }
}
