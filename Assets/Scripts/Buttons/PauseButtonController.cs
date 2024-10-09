using UnityEngine;

public class PauseButtonController : MonoBehaviour
{
    public void pauseGame() => PauseController.PauseGame();
    public void resumeGame() => PauseController.ResumeGame();
}
