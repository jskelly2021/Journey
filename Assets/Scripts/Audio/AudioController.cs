using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void playAudioClip() => AudioEventManager.playAudio(audioClip);
    public void setMasterVolume(float volumeLevel) => AudioEventManager.setVolume("MasterVolume", volumeLevel);
    public void setMenuFXVolume(float volumeLevel) => AudioEventManager.setVolume("MenuFXVolume", volumeLevel);
    public void setMusicFXVolume(float volumeLevel) => AudioEventManager.setVolume("MusicFXVolume", volumeLevel);
    public void setGameFXVolume(float volumeLevel) => AudioEventManager.setVolume("GameFXVolume", volumeLevel);
}
