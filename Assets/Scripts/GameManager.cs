using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private SceneLoader sceneLoader;

    public GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    private void OnEnable()
    {
        InputHandler.PauseAction += pauseGame;
        InputHandler.ResumeAction += resumeGame;
        QuitController.QuitGame += quit;
    }
    private void OnDisable()
    {
        InputHandler.PauseAction -= pauseGame;
        InputHandler.ResumeAction -= resumeGame;
        QuitController.QuitGame -= quit;
    }

    private void pauseGame()
    {
        Time.timeScale = 0.0f;
    }

    private void resumeGame()
    {
        Time.timeScale = 1.0f;
    }

    private void quit()
    {
        Application.Quit();
    }
}
