using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInputAction playerInput;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        InputController.SetActionMap += setActionMap;
        InputController.ToggleActionMap += toggleActionMap;
    }

    private void OnDiable()
    {
        InputController.SetActionMap -= setActionMap;
        InputController.ToggleActionMap -= toggleActionMap;
    }

    private void setActionMap(string actionMap)
    {
    }

    private void toggleActionMap(string actionMap)
    {
    }

}
