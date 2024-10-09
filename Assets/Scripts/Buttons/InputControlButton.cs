using UnityEngine;

public class InputControlButton : MonoBehaviour
{
    public void enableActionMap(string actionMap) => InputEvents.EnableActionMap(actionMap);
    public void disableActionMap(string actionMap) => InputEvents.DisableActionMap(actionMap);
}
