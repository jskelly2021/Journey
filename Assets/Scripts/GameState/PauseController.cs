public static class PauseController
{
    public static void Init() {}

    public static void PauseGame()
    {
        GameStateEvents.ChangeGameState(GameStates.Pause);
        UIEvents.EnableCanvas(UICanvases.HUD, false);
        UIEvents.EnableCanvas(UICanvases.PauseMenu, true);
        InputEvents.EnableActionMap("PauseMenu");
        InputEvents.DisableActionMap("Player");
    }

    public static void ResumeGame()
    {
        GameStateEvents.ChangeGameState(GameStates.Play);
        UIEvents.EnableCanvas(UICanvases.PauseMenu, false);
        UIEvents.EnableCanvas(UICanvases.HUD, true);
        InputEvents.EnableActionMap("Player");
        InputEvents.DisableActionMap("PauseMenu");
    }
}
