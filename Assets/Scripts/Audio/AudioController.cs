using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void playAudioClip()
    {
        Debug.Log("Requesting to play audio");
        AudioEventManager.playAudio(audioClip);
    }
}