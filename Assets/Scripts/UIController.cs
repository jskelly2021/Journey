using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas;

    private void OnEnable()
    {
        InputHandler.PauseAction += enablePauseMenu;
        InputHandler.ResumeAction += disablePauseMenu;
    }
    private void OnDisable()
    {
        InputHandler.PauseAction -= disablePauseMenu;
        InputHandler.ResumeAction -= disablePauseMenu;
    }

    private void enablePauseMenu() => pauseMenuCanvas.SetActive(true);
    private void disablePauseMenu() => pauseMenuCanvas.SetActive(false);
}
