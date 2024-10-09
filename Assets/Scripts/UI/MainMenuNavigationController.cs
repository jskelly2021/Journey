using UnityEngine;

public class MainMenuNavigationController : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic;

    private void OnEnable()
    {
        AudioEvents.PlayAudio(AudioGroup.Music, menuMusic, null);
    }

    private void OnDisable()
    {
        AudioEvents.StopAllAudioInGroup(AudioGroup.Music);
    }

    public void GoToStartMenu()
        => UIEvents.EnableCanvas(UICanvases.StartMenu, true);
    public void LeaveStartMenu()
        => UIEvents.EnableCanvas(UICanvases.StartMenu, false);

    public void GoToOptionsMenu()
        => UIEvents.EnableCanvas(UICanvases.OptionsMenu, true);
    public void LeaveOptionsMenu()
        =>  UIEvents.EnableCanvas(UICanvases.OptionsMenu, false);
}
