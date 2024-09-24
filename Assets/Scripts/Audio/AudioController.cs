using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void playMenuAudioClip() => AudioEventManager.playMenuAudio(audioClip);
    public void playGameAudioClip() => AudioEventManager.playGameAudio(audioClip, null);
    public void playMusicAudioClip() => AudioEventManager.playMusicAudio(audioClip);

    public void setMasterVolume(float volumeLevel) => AudioEventManager.setVolume(AudioGroup.Master, volumeLevel);
    public void setMenuFXVolume(float volumeLevel) => AudioEventManager.setVolume(AudioGroup.Menu, volumeLevel);
    public void setMusicVolume(float volumeLevel) => AudioEventManager.setVolume(AudioGroup.Music, volumeLevel);
    public void setGameFXVolume(float volumeLevel) => AudioEventManager.setVolume(AudioGroup.Game, volumeLevel);
}
