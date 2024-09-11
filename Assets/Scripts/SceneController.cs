using UnityEngine;
using Eflatun.SceneReference;
using System;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneReference sceneToLoad;
    [SerializeField] private SceneReference sceneToUnload;

    public static event Action<SceneReference> LoadScene;
    public static event Action<SceneReference> UnloadScene;
    public static event Action<SceneReference> SetActive;

    public void loadScene()
    {
        LoadScene(sceneToLoad);
    }

    public void unloadScene()
    {
        UnloadScene(sceneToUnload);
    }

    public void quitGame()
    {
    }
}
