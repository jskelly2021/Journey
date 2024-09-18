using UnityEngine;
using Eflatun.SceneReference;
using System;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneReference sceneToLoad;
    [SerializeField] private SceneReference sceneToUnload;

    public static event Action<SceneReference> LoadScene;
    public static event Action<SceneReference> UnloadScene;
    public static event Action<SceneReference> SetSceneActive;

    public void loadScene() => LoadScene?.Invoke(sceneToLoad);

    public void unloadScene() => UnloadScene?.Invoke(sceneToUnload);

    public void setSceneActive() => SetSceneActive?.Invoke(sceneToLoad);

    public void quitGame() {}
}
