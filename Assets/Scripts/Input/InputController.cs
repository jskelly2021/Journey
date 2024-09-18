using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static event Action<string> EnableActionMap;
    public static event Action<string> DisableActionMap;

    public void enableActionMap(string actionMap) => EnableActionMap?.Invoke(actionMap);
    public void disableActionMap(string actionMap) => DisableActionMap?.Invoke(actionMap);
}
