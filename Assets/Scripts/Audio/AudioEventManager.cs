using System;
using UnityEngine;

public static class AudioEventManager
{
    public static event Action<AudioGroup, AudioClip, Transform> OnPlayAudio;
    public static event Action<AudioGroup, float> OnSetVolume;

    public static void playAudio(AudioGroup audioGroup, AudioClip audioClip, Transform spawnPosition) 
        => OnPlayAudio?.Invoke(audioGroup, audioClip, spawnPosition);

    public static void setVolume(AudioGroup audioGroup, float volumeLevel) 
        => OnSetVolume?.Invoke(audioGroup, volumeLevel);
}
