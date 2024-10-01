using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void playMenuAudioClip() => AudioEvents.PlayAudio(AudioGroup.Menu, audioClip, null);
    public void playGameAudioClip() => AudioEvents.PlayAudio(AudioGroup.Game, audioClip, null);
    public void playMusicAudioClip() => AudioEvents.PlayAudio(AudioGroup.Music, audioClip, null);

    public void setMasterVolume(float volumeLevel) => AudioEvents.SetVolume(AudioGroup.Master, volumeLevel);
    public void setMenuFXVolume(float volumeLevel) => AudioEvents.SetVolume(AudioGroup.Menu, volumeLevel);
    public void setMusicVolume(float volumeLevel) => AudioEvents.SetVolume(AudioGroup.Music, volumeLevel);
    public void setGameFXVolume(float volumeLevel) => AudioEvents.SetVolume(AudioGroup.Game, volumeLevel);
}
