using System;
using UnityEngine;

public static class AudioEventManager
{
    public static event Action<AudioGroup, AudioClip, Transform> OnPlayAudio;
    public static event Action<AudioGroup, float> OnSetVolume;

    public static void playMenuAudio(AudioClip audioClip) 
        => OnPlayAudio?.Invoke(AudioGroup.Menu, audioClip, null);

    public static void playGameAudio(AudioClip audioClip, Transform spawnPosition) 
        => OnPlayAudio?.Invoke(AudioGroup.Game,audioClip, spawnPosition);
    
    public static void playMusicAudio(AudioClip audioClip) 
        => OnPlayAudio?.Invoke(AudioGroup.Music, audioClip, null);

    public static void setVolume(AudioGroup audioGroup, float volumeLevel) => OnSetVolume?.Invoke(audioGroup, volumeLevel);
}
