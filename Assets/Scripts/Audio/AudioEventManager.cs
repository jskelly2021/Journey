using System;
using UnityEditor;
using UnityEngine;

public static class AudioEventManager
{
    public static event Action<AudioGroup, AudioClip, Transform> OnPlayAudio;
    public static event Action<AudioGroup, float> OnSetVolume;
    public static event Action<AudioGroup, AudioClip, Transform> OnStopAudioClip;
    public static event Action<AudioGroup> OnStopAllAudio;

    public static void playAudio(AudioGroup audioGroup, AudioClip audioClip, Transform spawnPosition) 
        => OnPlayAudio?.Invoke(audioGroup, audioClip, spawnPosition);

    public static void setVolume(AudioGroup audioGroup, float volumeLevel) 
        => OnSetVolume?.Invoke(audioGroup, volumeLevel);

    public static void stopAudioClip(AudioGroup audioGroup, AudioClip audioClip, Transform location)
        => OnStopAudioClip?.Invoke(audioGroup, audioClip, location);

    public static void stopAllAudioInGroup(AudioGroup audioGroup)
        => OnStopAllAudio?.Invoke(audioGroup);
}
