using UnityEngine.InputSystem;

public class PausedInputHandler : InputHandler, PlayerInputAction.IPausedActions
{
    private void Start()
    {
        InputManager.Instance.PlayerInput.Paused.SetCallbacks(this);
    }

    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
            return;

        InputManager.Instance.PlayerInput.Paused.Disable();
        InputManager.Instance.PlayerInput.Player.Enable();

        base.Resume();
    }
}
