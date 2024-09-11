using UnityEngine;
using Eflatun.SceneReference;

public class SceneController : MonoBehaviour
{
    private SceneLoader sceneLoader;
    private GameManager gameManager;
    [SerializeField] private SceneReference thisScene;
    [SerializeField] private SceneReference nextScene;

    private void Awake()
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>().Instance;   
        gameManager = GameObject.FindObjectOfType<GameManager>().Instance;
    }

    public void loadScene()
    {
        sceneLoader.loadScene(nextScene);
    }

    public void unloadScene()
    {
        sceneLoader.unloadScene(thisScene);
    }

    public void quitGame()
    {
        gameManager.quit();
    }
}
