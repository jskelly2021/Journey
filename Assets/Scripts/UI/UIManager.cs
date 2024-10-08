using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas;

    private void OnEnable()
    {
        GameStateEvents.OnPauseGame += enablePauseMenu;
        GameStateEvents.OnResumeGame += disablePauseMenu;
    }
    private void OnDisable()
    {
        GameStateEvents.OnPauseGame -= enablePauseMenu;
        GameStateEvents.OnResumeGame -= disablePauseMenu;
    }

    private void enablePauseMenu() => pauseMenuCanvas.SetActive(true);
    private void disablePauseMenu() => pauseMenuCanvas.SetActive(false);
}
