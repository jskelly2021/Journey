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
        Debug.Log("Game Paused");
    }
}
