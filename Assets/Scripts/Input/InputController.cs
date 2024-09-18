using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static event Action<string> EnableActionMap;
    
    public void enableActionMap(string actionMap)
    {
        EnableActionMap?.Invoke(actionMap);
    }
}
