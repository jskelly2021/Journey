using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    private PlayerInputAction playerInput;
    
    private InputHandler playerInputHandler;
    private InputHandler pausedInputHandler;

    public static InputManager Instance { get { return instance; } }
    public PlayerInputAction PlayerInput { get { return playerInput; } }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        playerInput = new PlayerInputAction();

        playerInputHandler = new PlayerInputHandler(playerInput);
        pausedInputHandler = new PausedInputHandler(playerInput);
    }

    private void Start()
    {
        disableActionMap("Player");
        disableActionMap("Paused");
    }

    private void OnEnable()
    {
        playerInput.Enable();
        InputEvents.OnEnableActionMap += enableActionMap;
        InputEvents.OnDisableActionMap += disableActionMap;
    }

    private void OnDisable()
    {
        playerInput.Disable();
        InputEvents.OnEnableActionMap -= enableActionMap;
        InputEvents.OnDisableActionMap -= disableActionMap;
   }

    private void enableActionMap(string actionMap)
    {
        Debug.Log("Enabling" + actionMap);
        PlayerInput.asset.FindActionMap(actionMap).Enable();
    } 
    
    private void disableActionMap(string actionMap) => PlayerInput.asset.FindActionMap(actionMap).Disable();
}
