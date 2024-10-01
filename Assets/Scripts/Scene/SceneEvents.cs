using Eflatun.SceneReference;
using System;

public class SceneEvents
{
    public static event Action<SceneReference> OnLoadScene;
    public static event Action<SceneReference> OnUnloadScene;
    public static event Action<SceneReference> OnSetSceneActive;

    public static void LoadScene(SceneReference sceneRef) => OnLoadScene?.Invoke(sceneRef);
    public static void UnloadScene(SceneReference sceneRef) => OnUnloadScene?.Invoke(sceneRef);
    public static void SetSceneActive(SceneReference sceneRef) => OnSetSceneActive?.Invoke(sceneRef);
}
