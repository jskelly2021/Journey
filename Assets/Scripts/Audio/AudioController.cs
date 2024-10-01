using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void playMenuAudioClip() => AudioEventManager.PlayAudio(AudioGroup.Menu, audioClip, null);
    public void playGameAudioClip() => AudioEventManager.PlayAudio(AudioGroup.Game, audioClip, null);
    public void playMusicAudioClip() => AudioEventManager.PlayAudio(AudioGroup.Music, audioClip, null);

    public void setMasterVolume(float volumeLevel) => AudioEventManager.SetVolume(AudioGroup.Master, volumeLevel);
    public void setMenuFXVolume(float volumeLevel) => AudioEventManager.SetVolume(AudioGroup.Menu, volumeLevel);
    public void setMusicVolume(float volumeLevel) => AudioEventManager.SetVolume(AudioGroup.Music, volumeLevel);
    public void setGameFXVolume(float volumeLevel) => AudioEventManager.SetVolume(AudioGroup.Game, volumeLevel);
}
