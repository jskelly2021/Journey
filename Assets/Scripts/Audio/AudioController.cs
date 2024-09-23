using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void playMenuAudioClip() => AudioEventManager.playMenuAudio(audioClip);
    public void playGameAudioClip(Transform spawnPosition) => AudioEventManager.playGameAudio(audioClip, spawnPosition);
    public void playMusicAudioClip() => AudioEventManager.playMusicAudio(audioClip);
    public void setMasterVolume(float volumeLevel) => AudioEventManager.setVolume("MasterVolume", volumeLevel);
    public void setMenuFXVolume(float volumeLevel) => AudioEventManager.setVolume("MenuFXVolume", volumeLevel);
    public void setMusicVolume(float volumeLevel) => AudioEventManager.setVolume("MusicVolume", volumeLevel);
    public void setGameFXVolume(float volumeLevel) => AudioEventManager.setVolume("GameFXVolume", volumeLevel);
}
