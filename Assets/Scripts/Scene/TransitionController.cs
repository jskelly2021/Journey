public static class TransitionController
{
    public static void Init() {}

    public static void StartGame()
    {
        UIEvents.EnableCanvas(UICanvases.MainMenu, false);
        UIEvents.EnableCanvas(UICanvases.HUD, true);
        SceneEvents.SetSceneActive(Scenes.Main);
        InputEvents.EnableActionMap("Player");
        InputEvents.DisableActionMap("UI");
    }

    public static void GoToMainMenu()
    {
        UIEvents.EnableCanvas(UICanvases.HUD, false);
        UIEvents.EnableCanvas(UICanvases.MainMenu, true);
        SceneEvents.SetSceneActive(Scenes.UI);
        SceneEvents.UnloadScene(Scenes.Main);
        InputEvents.EnableActionMap("UI");
        InputEvents.DisableActionMap("Player");
    }
}
