using System;
using UnityEngine;

public static class AudioEventManager
{
    public static event Action<AudioGroup, AudioClip, Transform> OnPlayAudio;
    public static event Action<AudioGroup, float> OnSetVolume;
    public static event Action<AudioGroup, AudioClip, Transform> OnStopAudioClip;
    public static event Action<AudioGroup> OnStopAllAudio;

    public static void PlayAudio(AudioGroup audioGroup, AudioClip audioClip, Transform spawnPosition) 
        => OnPlayAudio?.Invoke(audioGroup, audioClip, spawnPosition);

    public static void SetVolume(AudioGroup audioGroup, float volumeLevel) 
        => OnSetVolume?.Invoke(audioGroup, volumeLevel);

    public static void StopAudioClip(AudioGroup audioGroup, AudioClip audioClip, Transform location)
        => OnStopAudioClip?.Invoke(audioGroup, audioClip, location);

    public static void StopAllAudioInGroup(AudioGroup audioGroup)
        => OnStopAllAudio?.Invoke(audioGroup);
}
