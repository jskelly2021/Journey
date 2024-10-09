using UnityEngine.InputSystem;

public class PlayerInputHandler : InputHandler, PlayerInputAction.IPlayerActions
{
    public PlayerInputHandler(PlayerInputAction playerInput) : base(playerInput)
    {
        base.playerInput.Player.SetCallbacks(this);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
            return;

        PauseController.PauseGame();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
            return;

        StoreController.OpenStore();
    }
}
