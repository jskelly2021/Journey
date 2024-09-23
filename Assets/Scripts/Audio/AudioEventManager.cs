using System;
using UnityEngine;

public class AudioEventManager
{
    public static event Action<AudioClip> OnPlayMenuAudio;
    public static event Action<AudioClip, Transform> OnPlayGameAudio;
    public static event Action<AudioClip> OnPlayMusicAudio;
    public static event Action<string, float> OnSetVolume;

    public static void playMenuAudio(AudioClip audioClip) => OnPlayMenuAudio?.Invoke(audioClip);
    public static void playGameAudio(AudioClip audioClip, Transform spawnPosition) => OnPlayGameAudio?.Invoke(audioClip, spawnPosition);
    public static void playMusicAudio(AudioClip audioClip) => OnPlayMusicAudio?.Invoke(audioClip);
    public static void setVolume(string audioGroup, float volumeLevel) => OnSetVolume?.Invoke(audioGroup, volumeLevel);
}
