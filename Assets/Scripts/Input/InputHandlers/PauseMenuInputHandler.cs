using UnityEngine.InputSystem;

public class PauseMenuInputHandler : InputHandler, PlayerInputAction.IPauseMenuActions
{
    public PauseMenuInputHandler(PlayerInputAction playerInput) : base(playerInput)
    {
        playerInput.PauseMenu.SetCallbacks(this);
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
            return;

        PauseController.ResumeGame();
    }
}
