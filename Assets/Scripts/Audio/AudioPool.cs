using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPool
{
    private List<AudioSource> audioSources;
    private int audioPoolSize;
    private AudioSource audioPrefab;
    private Transform parentTransform;

    public AudioPool(int audioPoolSize, AudioSource audioPrefab, Transform parentTransform)
    {
        audioSources = new List<AudioSource>();
        this.audioPoolSize = audioPoolSize;
        this.audioPrefab = audioPrefab;
        this.parentTransform = parentTransform;
        initAudioPool();
    }

    private void initAudioPool()
    {
        for (int i = 0; i < audioPoolSize; i++)
        {
            AudioSource audioSource = Object.Instantiate(audioPrefab, parentTransform);
            audioSource.gameObject.SetActive(false);
            audioSources.Add(audioSource);
        }
    }

    public AudioSource getAudioSource()
    {
        foreach (var audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
                return audioSource;
        }
        return null;
    }

    public IEnumerator returnAudioSource(AudioSource audioSource)
    {
        while (audioSource.isPlaying)
            yield return null;

        audioSource.Stop();
        audioSource.clip = null;
        audioSource.gameObject.SetActive(false);
    }
}
