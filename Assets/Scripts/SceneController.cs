using UnityEngine;
using Eflatun.SceneReference;
using System;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneReference thisScene;
    [SerializeField] private SceneReference nextScene;

    public static event Action<SceneReference> LoadScene;
    public static event Action<SceneReference> UnloadScene;

    public void loadScene()
    {
        LoadScene(nextScene);
    }

    public void unloadScene()
    {
        UnloadScene(thisScene);
    }

    public void quitGame()
    {
    }
}
