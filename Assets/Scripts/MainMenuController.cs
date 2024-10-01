using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private void OnEnable()
    {
        AudioEventManager.PlayAudio(AudioGroup.Music, audioClip, null);
    }

    private void OnDisable()
    {
        AudioEventManager.StopAllAudioInGroup(AudioGroup.Music);
    }
}
