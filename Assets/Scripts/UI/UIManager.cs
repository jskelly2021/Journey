using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject startMenuCanvas;
    [SerializeField] private GameObject optionsMenuCanvas;
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private GameObject storeMenuCanvas;
    [SerializeField] private GameObject hudCanvas;

    private void OnEnable()
    {
        GameStateEvents.OnPauseGame += enablePauseMenu;
        GameStateEvents.OnResumeGame += disablePauseMenu;

        UIEvents.OnEnableCanvas += enableCanvas;
    }
    private void OnDisable()
    {
        GameStateEvents.OnPauseGame -= enablePauseMenu;
        GameStateEvents.OnResumeGame -= disablePauseMenu;
        UIEvents.OnEnableCanvas -= enableCanvas;
    }

    private void enablePauseMenu() => pauseMenuCanvas.SetActive(true);
    private void disablePauseMenu() => pauseMenuCanvas.SetActive(false);

    private void enableCanvas(UICanvases canvas, bool setActive) => GetCanvas(canvas).SetActive(setActive);
    
    private GameObject GetCanvas(UICanvases canvas)
    {
        switch (canvas)
        {
            case UICanvases.MainMenu:
                return mainMenuCanvas;
            case UICanvases.StartMenu:
                return startMenuCanvas;
            case UICanvases.OptionsMenu:
                return optionsMenuCanvas;
            case UICanvases.PauseMenu:
                return pauseMenuCanvas;
            case UICanvases.StoreMenu:
                return storeMenuCanvas;
            case UICanvases.HUD:
                return hudCanvas;
            default:
                return null;
        }
    }
}
