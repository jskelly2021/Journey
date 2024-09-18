using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : InputHandler, PlayerInputAction.IPlayerActions
{
    private void Start()
    {
        InputManager.Instance.PlayerInput.Player.SetCallbacks(this);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log("Pausing Game from PlayerInputHandler");
        base.Pause();
    }
}
