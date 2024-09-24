using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void playMenuAudioClip() => AudioEventManager.playAudio(AudioGroup.Menu, audioClip, null);
    public void playGameAudioClip() => AudioEventManager.playAudio(AudioGroup.Game, audioClip, null);
    public void playMusicAudioClip() => AudioEventManager.playAudio(AudioGroup.Music, audioClip, null);

    public void setMasterVolume(float volumeLevel) => AudioEventManager.setVolume(AudioGroup.Master, volumeLevel);
    public void setMenuFXVolume(float volumeLevel) => AudioEventManager.setVolume(AudioGroup.Menu, volumeLevel);
    public void setMusicVolume(float volumeLevel) => AudioEventManager.setVolume(AudioGroup.Music, volumeLevel);
    public void setGameFXVolume(float volumeLevel) => AudioEventManager.setVolume(AudioGroup.Game, volumeLevel);
}
