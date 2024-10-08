using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private GameObject optionsMenuCanvas;
    [SerializeField] private GameObject storeCanvas;

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
    
    public GameObject GetCanvas(UICanvases canvas)
    {
        switch (canvas)
        {
            case UICanvases.MainMenu:
                return mainMenuCanvas;
            case UICanvases.PauseMenu:
                return pauseMenuCanvas;
            case UICanvases.OptionsMenu:
                return optionsMenuCanvas;
            case UICanvases.StoreMenu:
                return storeCanvas;
            default:
                return null;
        }
    }
}
