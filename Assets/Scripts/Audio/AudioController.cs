using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void playAudioClip() => AudioEventManager.playAudio(audioClip);
    public void setMasterVolume(float volumeLevel) => AudioEventManager.setVolume("MasterVolume", volumeLevel);
}