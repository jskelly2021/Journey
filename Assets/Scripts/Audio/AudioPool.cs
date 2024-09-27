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

    public AudioSource getAvailableAudioSource()
    {
        foreach (var audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
                return audioSource;
        }
        return null;
    }

    public AudioSource getActiveAudioSource(AudioClip audioClip, Transform location)
    {
        if (audioClip == null)
            return null;

        foreach (var audioSource in audioSources)
        {
            if (audioSource.isPlaying && audioSource.clip == audioClip)
            {
                if (location == null || audioSource.transform.position == location.position)
                    return audioSource;
            }
        }
        return null;
    }

    public void returnAudioSource(AudioClip audioClip, Transform location)
    {
        returnAudioSource(getActiveAudioSource(audioClip, location));
    }

    public void returnAudioSource(AudioSource audioSource)
    {
        if (audioSource == null)
            return;

        audioSource.Stop();
        audioSource.clip = null;
        audioSource.gameObject.SetActive(false);
    }

    public void stopAllSources()
    {
        foreach (var audioSource in audioSources)
        {
            if (audioSource.isPlaying)
                returnAudioSource(audioSource);
        }
    }

    public IEnumerator returnAudioSourceWhenFinished(AudioSource audioSource)
    {
        while (audioSource.isPlaying)
            yield return null;

        returnAudioSource(audioSource);
    }
}
