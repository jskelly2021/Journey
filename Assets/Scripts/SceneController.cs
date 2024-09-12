using UnityEngine;
using Eflatun.SceneReference;
using System;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneReference sceneToLoad;
    [SerializeField] private SceneReference sceneToUnload;

    public static event Action<SceneReference, bool> LoadScene;
    public static event Action<SceneReference> UnloadScene;

    public void loadScene(bool setActive)
    {
        LoadScene(sceneToLoad, setActive);
    }

    public void unloadScene()
    {
        UnloadScene(sceneToUnload);
    }

    public void quitGame()
    {
    }
}
