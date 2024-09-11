using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private SceneLoader sceneLoader;

    public GameManager Instance 
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }

    private void Awake()
    {
        sceneLoader = GameObject.FindFirstObjectByType<SceneLoader>();
        sceneLoader.loadScene("MainMenu");
    }
}
