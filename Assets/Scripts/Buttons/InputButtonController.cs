using UnityEngine;

public class InputButtonController : MonoBehaviour
{
    public void enableActionMap(string actionMap) => InputEvents.EnableActionMap(actionMap);
    public void disableActionMap(string actionMap) => InputEvents.DisableActionMap(actionMap);
}
