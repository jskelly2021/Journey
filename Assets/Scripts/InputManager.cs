using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput; 

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        InputController.SetActionMap += setActionMap;
        InputController.EnableActionMap += enableActionMap;
        InputController.DisableActionMap += disableActionMap;
    }

    private void OnDiable()
    {
        InputController.SetActionMap -= setActionMap;
        InputController.EnableActionMap -= enableActionMap;
        InputController.DisableActionMap -= disableActionMap;
    }

    private void setActionMap(string actionMap)
    {
       playerInput.SwitchCurrentActionMap(actionMap);
    }

    private void enableActionMap(string actionMap)
    {
        playerInput.actions.FindActionMap(actionMap).Enable();
    }

    private void disableActionMap(string actionMap)
    {
        playerInput.actions.FindActionMap(actionMap).Disable();
    }
}
