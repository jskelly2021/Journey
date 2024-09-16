using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private string actionMap;

    public static event Action<string> SetActionMap;
    public static event Action<string> EnableActionMap;
    public static event Action<string> DisableActionMap;
    
    public void setActionMap()
    {
        SetActionMap(actionMap);
    }

    public void enableActionMap()
    {
        EnableActionMap(actionMap);
    }

    public void disableActionMap()
    {
        DisableActionMap(actionMap);
    }
}
