using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioSource audioSourcePrefab;

    private List<AudioSource> audioSourcePool;
    [SerializeField] private int audioSourcePoolSize = 10;

    [SerializeField] private AudioMixer audioMixer;

    public static AudioManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        instance = this;
        initAudioSourcePool();
    }

    private void OnEnable()
    {
        AudioEventManager.OnPlayAudio += playAudio;
        AudioEventManager.OnSetVolume += setVolume;
    }
    private void OnDisable()
    {
        AudioEventManager.OnPlayAudio -= playAudio;
        AudioEventManager.OnSetVolume -= setVolume;
    }

    private void playAudio(AudioClip audioClip)
    {
        AudioSource audioSource = getAudioSource();
        audioSource.clip = audioClip;
        audioSource.gameObject.SetActive(true);
        audioSource.Play();
        StartCoroutine(returnAudioSource(audioSource));
    }

    private void setVolume(string audioGroup, float volumeLevel)
    {
        audioMixer.SetFloat(audioGroup, Mathf.Log10(volumeLevel) * 20f);
    }

    private void initAudioSourcePool()
    {
        audioSourcePool = new List<AudioSource>();

        for (int i = 0; i < audioSourcePoolSize; i++)
        {
            AudioSource audioSource = Instantiate(audioSourcePrefab);
            audioSource.transform.parent = gameObject.transform;
            audioSource.gameObject.SetActive(false);
            audioSourcePool.Add(audioSource);
        }
    }

    private AudioSource getAudioSource()
    {
        foreach (var audioSource in audioSourcePool)
        {
            if (!audioSource.isPlaying)
                return audioSource;
        }
        return null;
    }

    private IEnumerator returnAudioSource(AudioSource audioSource)
    {
        while (audioSource.isPlaying)
            yield return null;

        audioSource.Stop();
        audioSource.clip = null;
        audioSource.gameObject.SetActive(false);
    }

}
