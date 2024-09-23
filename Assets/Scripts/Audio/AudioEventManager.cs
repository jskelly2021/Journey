using System;
using UnityEngine;

public class AudioEventManager
{
    public static event Action<AudioClip> OnPlayAudio;
    public static event Action<string, float> OnSetVolume;

    public static void playAudio(AudioClip audioClip) => OnPlayAudio?.Invoke(audioClip);
    public static void setVolume(string audioGroup, float volumeLevel) => OnSetVolume?.Invoke(audioGroup, volumeLevel);
}
