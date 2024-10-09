using UnityEngine;
using Eflatun.SceneReference;

public class SceneButtonController : MonoBehaviour
{
    [SerializeField] private SceneReference sceneToLoad;
    [SerializeField] private SceneReference sceneToUnload;

    public void loadScene() => SceneEvents.LoadScene(sceneToLoad);
    public void unloadScene() => SceneEvents.UnloadScene(sceneToUnload);
    public void setSceneActive() => SceneEvents.LoadScene(sceneToLoad);
}
