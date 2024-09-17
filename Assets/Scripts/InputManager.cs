using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    private PlayerInputAction playerInput;

    public static InputManager Instance { get { return instance; } }
    public PlayerInputAction PlayerInput { get { return playerInput; } }

    private void Awake()
    {
        if (instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        playerInput = new PlayerInputAction();
    }

    private void OnEnable()
    {
        playerInput.Enable();
        InputController.EnableActionMap += enableActionMap;
    }

    private void OnDisable()
    {
        playerInput.Disable();
        InputController.EnableActionMap -= enableActionMap;
    }

    private void enableActionMap(string actionMap)
    {
        Debug.Log("Activating " + actionMap);
        playerInput.asset.FindActionMap(actionMap).Enable();
    }
}
