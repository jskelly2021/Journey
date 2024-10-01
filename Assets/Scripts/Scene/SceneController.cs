using UnityEngine;
using Eflatun.SceneReference;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneReference sceneToLoad;
    [SerializeField] private SceneReference sceneToUnload;

    public void loadScene() => SceneEvents.loadScene(sceneToLoad);
    public void unloadScene() => SceneEvents.unloadScene(sceneToUnload);
    public void setSceneActive() => SceneEvents.loadScene(sceneToLoad);
}
