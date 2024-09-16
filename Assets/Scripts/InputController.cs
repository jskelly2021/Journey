using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static event Action<string> SetActionMap;
    public static event Action<string> EnableActionMap;
    public static event Action<string> DisableActionMap;
    
    public void setActionMap(string actionMap)
    {
        SetActionMap(actionMap);
    }

    public void enableActionMap(string actionMap)
    {
        EnableActionMap(actionMap);
    }

    public void disableActionMap(string actionMap)
    {
        DisableActionMap(actionMap);
    }
}
