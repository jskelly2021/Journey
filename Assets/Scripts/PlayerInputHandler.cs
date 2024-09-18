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
        if(context.phase == InputActionPhase.Performed)
            base.Pause();
        
        Debug.Log("Pausing Game from PlayerInputHandler");
    }
}
