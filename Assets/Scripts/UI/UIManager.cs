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
        UIEvents.OnEnableCanvas += enableCanvas;
        UIEvents.OnDisableAllCanvases += disableAllCanvases;
    }
    private void OnDisable()
    {
        UIEvents.OnEnableCanvas -= enableCanvas;
    }

    private void enableCanvas(UICanvases canvas, bool setActive) => GetCanvas(canvas).SetActive(setActive);
    
    private void disableAllCanvases()
    {
        mainMenuCanvas.SetActive(false);
        pauseMenuCanvas.SetActive(false);
        storeMenuCanvas.SetActive(false);
        hudCanvas.SetActive(false);
    }

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
