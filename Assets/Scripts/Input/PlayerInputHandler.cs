using UnityEngine.InputSystem;

public class PlayerInputHandler : InputHandler, PlayerInputAction.IPlayerActions
{
    private void Start()
    {
        InputManager.Instance.PlayerInput.Player.SetCallbacks(this);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
            return;

        InputManager.Instance.PlayerInput.Player.Disable();
        InputManager.Instance.PlayerInput.Paused.Enable();

        base.Pause();
    }
}
