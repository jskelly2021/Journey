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

    public void quit()
    {
        Application.Quit();
    }
}
