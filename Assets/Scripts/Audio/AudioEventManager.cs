using System;
using UnityEngine;

public class AudioEventManager
{
    public static event Action<AudioClip> OnPlayAudio;    

    public static void playAudio(AudioClip audioClip) 
    {
        Debug.Log("Invoking event");
        OnPlayAudio?.Invoke(audioClip);
    }
}
