using Eflatun.SceneReference;
using System;

public class SceneEvents
{
    public static event Action<SceneReference> OnLoadScene;
    public static event Action<SceneReference> OnUnloadScene;
    public static event Action<SceneReference> OnSetSceneActive;

    public static void loadScene(SceneReference sceneRef) => OnLoadScene?.Invoke(sceneRef);
    public static void unloadScene(SceneReference sceneRef) => OnUnloadScene?.Invoke(sceneRef);
    public static void setSceneActive(SceneReference sceneRef) => OnSetSceneActive?.Invoke(sceneRef);
}
