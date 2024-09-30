using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour, PlayerInputAction.IPlayerActions
{
    private void Start()
    {
        InputManager.Instance.PlayerInput.Player.SetCallbacks(this);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed)
            return;

        GameStateEvents.SetGameState(GameStates.Pause);

        InputManager.Instance.PlayerInput.Paused.Enable();
        InputManager.Instance.PlayerInput.Player.Disable();
    }
}
