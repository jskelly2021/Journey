using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : PlayerInputAction.IPlayerActions
{
    PlayerInputAction playerInput;

    public PlayerInputHandler(PlayerInputAction playerInput)
    {
        this.playerInput = playerInput;
        playerInput.Player.SetCallbacks(this);
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
