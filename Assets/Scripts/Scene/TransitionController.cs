public static class TransitionController
{
    public static void Init() {}

    public static void StartGame()
    {
        UIEvents.DisableAllCanvases();
        UIEvents.EnableCanvas(UICanvases.HUD, true);
        SceneEvents.SetSceneActive(Scenes.Main);
        InputEvents.EnableActionMap(ActionMaps.Player);
        InputEvents.DisableActionMap(ActionMaps.UI);
    }

    public static void GoToMainMenu()
    {
        UIEvents.DisableAllCanvases();
        UIEvents.EnableCanvas(UICanvases.MainMenu, true);
        SceneEvents.SetSceneActive(Scenes.UI);
        SceneEvents.UnloadScene(Scenes.Main);
        InputEvents.EnableActionMap(ActionMaps.UI);
        InputEvents.DisableActionMap(ActionMaps.PauseMenu);
        InputEvents.DisableActionMap(ActionMaps.Player);
    }
}
