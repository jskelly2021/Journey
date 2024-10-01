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

        GameStateEvents.SetGameState(GameStates.Pause);

        playerInput.Paused.Enable();
        playerInput.Player.Disable();
    }
}
