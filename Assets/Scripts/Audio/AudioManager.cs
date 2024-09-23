using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioMixer audioMixer;

    private List<AudioSource> menuAudioPool;
    private List<AudioSource> gameAudioPool;
    private List<AudioSource> musicAudioPool;

    [SerializeField] private int menuAudioPoolSize = 3;
    [SerializeField] private int gameAudioPoolSize = 10;
    [SerializeField] private int musicAudioPoolSize = 1;

    [SerializeField] private AudioSource menuAudioPrefab;
    [SerializeField] private AudioSource gameAudioPrefab;
    [SerializeField] private AudioSource musicAudioPrefab;

    public static AudioManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        instance = this;
        menuAudioPool = initAudioPool(menuAudioPoolSize, menuAudioPrefab);
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

    private List<AudioSource> initAudioPool(int audioPoolSize, AudioSource audioPrefab)
    {
        List<AudioSource> audioPool = new List<AudioSource>();

        for (int i = 0; i < audioPoolSize; i++)
        {
            AudioSource audioSource = Instantiate(audioPrefab);
            audioSource.transform.parent = gameObject.transform;
            audioSource.gameObject.SetActive(false);
            audioPool.Add(audioSource);
        }
        return audioPool;
    }

    private AudioSource getAudioSource()
    {
        foreach (var audioSource in menuAudioPool)
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
