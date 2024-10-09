using System;

public class SceneEvents
{
    public static event Action<Scenes> OnLoadScene;
    public static event Action<Scenes> OnUnloadScene;
    public static event Action<Scenes> OnSetSceneActive;

    public static void LoadScene(Scenes scene) => OnLoadScene?.Invoke(scene);
    public static void UnloadScene(Scenes scene) => OnUnloadScene?.Invoke(scene);
    public static void SetSceneActive(Scenes scene) => OnSetSceneActive?.Invoke(scene);
}
