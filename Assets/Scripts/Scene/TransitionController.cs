public static class TransitionController
{
    public static void Init() {}

    public static void StartGame()
    {
        UIEvents.DisableAllCanvases();
        UIEvents.EnableCanvas(UICanvases.HUD, true);
        SceneEvents.SetSceneActive(Scenes.Main);
        InputEvents.EnableActionMap("Player");
        InputEvents.DisableActionMap("UI");
    }

    public static void GoToMainMenu()
    {
        UIEvents.DisableAllCanvases();
        UIEvents.EnableCanvas(UICanvases.MainMenu, true);
        SceneEvents.SetSceneActive(Scenes.UI);
        SceneEvents.UnloadScene(Scenes.Main);
        InputEvents.EnableActionMap("UI");
        InputEvents.DisableActionMap("PauseMenu");
        InputEvents.DisableActionMap("Player");
    }
}
