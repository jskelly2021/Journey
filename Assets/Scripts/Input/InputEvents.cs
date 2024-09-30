using System;

public class InputEvents
{
    public static event Action<string> OnEnableActionMap;
    public static event Action<string> OnDisableActionMap;

    public static void EnableActionMap(string actionMap) => OnEnableActionMap?.Invoke(actionMap);
    public static void DisableActionMap(string actionMap) => OnDisableActionMap?.Invoke(actionMap);
}
