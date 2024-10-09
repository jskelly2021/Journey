public static class TransitionController
{
    public static void Init() {}

    public static void StartGame()
    {
        UIEvents.EnableCanvas(UICanvases.MainMenu, false);
        UIEvents.EnableCanvas(UICanvases.HUD, true);
        //TODO
        //SceneEvents.SetSceneActive(null);
        InputEvents.EnableActionMap("Player");
        InputEvents.DisableActionMap("UI");
    }

    public static void GoToMainMenu()
    {
        UIEvents.EnableCanvas(UICanvases.HUD, false);
        UIEvents.EnableCanvas(UICanvases.MainMenu, true);
        //TODO
        //SceneEvents.SetSceneActive(null);
        //SceneEvents.UnloadScene(null);
        InputEvents.EnableActionMap("UI");
        InputEvents.DisableActionMap("Player");
    }
}
