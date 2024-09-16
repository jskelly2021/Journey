using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, PlayerInputAction.IPlayerActions
{
    private static PlayerInputAction playerInput;

    public static PlayerInputAction PlayerInput 
    { 
        get 
        { 
            if (playerInput == null) return new PlayerInputAction();
            return playerInput; 
        } 
    }

    private void Awake()
    {
        playerInput = new PlayerInputAction();
        playerInput.Player.SetCallbacks(this);
    }

    private void OnEnable()
    {
        playerInput.Enable();
        InputController.EnableActionMap += enableActionMap;
    }

    private void OnDiable()
    {
        playerInput.Disable();
        InputController.EnableActionMap -= enableActionMap;
    }

    private void enableActionMap(string actionMap)
    {
        Debug.Log("Toggling " + actionMap);
        playerInput.asset.FindActionMap(actionMap).Enable();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log("Game Paused");
    }
}
