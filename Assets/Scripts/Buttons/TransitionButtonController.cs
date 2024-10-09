using UnityEngine;

public class TransitionButtonController : MonoBehaviour
{
    public void startGame() => TransitionController.StartGame();
    public void goToMainMenu() => TransitionController.GoToMainMenu();
}
