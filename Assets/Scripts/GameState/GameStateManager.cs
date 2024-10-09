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
        GameStateEvents.OnResumeGame += resumeGame;
        GameStateEvents.OnPauseGame += pauseGame;
        GameStateEvents.OnQuitGame += quitGame;

    }
    private void OnDisable()
    {
        GameStateEvents.OnResumeGame -= resumeGame;
        GameStateEvents.OnPauseGame -= pauseGame;
        GameStateEvents.OnQuitGame -= quitGame;
    }

    private void resumeGame()
    {
        Time.timeScale = 1.0f;
        UIEvents.EnableCanvas(UICanvases.PauseMenu, false);
    }

    private void pauseGame()
    {
        Time.timeScale = 0.0f;
        UIEvents.EnableCanvas(UICanvases.PauseMenu, true);
    }

    private void quitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
