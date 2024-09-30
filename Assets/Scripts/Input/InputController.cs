using UnityEngine;

public class InputController : MonoBehaviour
{
    public void enableActionMap(string actionMap) => InputEvents.EnableActionMap(actionMap);
    public void disableActionMap(string actionMap) => InputEvents.DisableActionMap(actionMap);
}
