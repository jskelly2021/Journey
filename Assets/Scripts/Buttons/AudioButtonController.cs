using UnityEngine;

public class AudioButtonController : MonoBehaviour
{
    public void setMasterVolume(float volumeLevel) => AudioEvents.SetVolume(AudioGroup.Master, volumeLevel);
    public void setMenuFXVolume(float volumeLevel) => AudioEvents.SetVolume(AudioGroup.Menu, volumeLevel);
    public void setMusicVolume(float volumeLevel) => AudioEvents.SetVolume(AudioGroup.Music, volumeLevel);
    public void setGameFXVolume(float volumeLevel) => AudioEvents.SetVolume(AudioGroup.Game, volumeLevel);
}
