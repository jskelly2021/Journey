using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void GoToMainMenu()
    {
        AudioEvents.PlayAudio(AudioGroup.Music, audioClip, null);
        InputEvents.EnableActionMap("UI");
        UIEvents.EnableCanvas(UICanvases.MainMenu, true);
    }
    public void LeaveMainMenu()
    {
        AudioEvents.StopAllAudioInGroup(AudioGroup.Music);
        InputEvents.DisableActionMap("UI");
        UIEvents.EnableCanvas(UICanvases.MainMenu, false);
    }

    public void GoToStartMenu()
    {
        UIEvents.EnableCanvas(UICanvases.StartMenu, true);
    }
    public void LeaveStartMenu()
    {
        UIEvents.EnableCanvas(UICanvases.StartMenu, false);
    }

    public void GoToOptionsMenu()
    {
        UIEvents.EnableCanvas(UICanvases.OptionsMenu, true);
    }
    public void LeaveOptionsMenu()
    {
        UIEvents.EnableCanvas(UICanvases.OptionsMenu, false);
    }
}
