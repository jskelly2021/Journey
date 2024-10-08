using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private void OnEnable()
    {
        AudioEvents.PlayAudio(AudioGroup.Music, audioClip, null);
    }

    private void OnDisable()
    {
        AudioEvents.StopAllAudioInGroup(AudioGroup.Music);
    }
}
