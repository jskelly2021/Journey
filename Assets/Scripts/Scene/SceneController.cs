using UnityEngine;
using Eflatun.SceneReference;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneReference sceneToLoad;
    [SerializeField] private SceneReference sceneToUnload;

    public void loadScene() => SceneEventManager.loadScene(sceneToLoad);
    public void unloadScene() => SceneEventManager.unloadScene(sceneToUnload);
    public void setSceneActive() => SceneEventManager.loadScene(sceneToLoad);
}
