using System;

public class InputEvents
{
    public static event Action<ActionMaps> OnEnableActionMap;
    public static event Action<ActionMaps> OnDisableActionMap;

    public static void EnableActionMap(ActionMaps actionMap) => OnEnableActionMap?.Invoke(actionMap);
    public static void DisableActionMap(ActionMaps actionMap) => OnDisableActionMap?.Invoke(actionMap);
}
