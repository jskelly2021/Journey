using UnityEngine.InputSystem;

public class PausedInputHandler : InputHandler, PlayerInputAction.IPausedActions
{
    public PausedInputHandler(PlayerInputAction playerInput) : base(playerInput)
    {
        playerInput.Paused.SetCallbacks(this);
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
            return;

        playerInput.Paused.Disable();
        playerInput.Player.Enable();

        GameStateEvents.SetGameState(GameStates.Play);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
            return;

        UIEvents.enableCanvas(UICanvases.StoreMenu, true);
    }
}
