using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioMixer audioMixer;

    private AudioPool menuAudioPool;
    private AudioPool gameAudioPool;
    private AudioPool musicAudioPool;

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

        menuAudioPool = new AudioPool(menuAudioPoolSize, menuAudioPrefab, new GameObject("MenuAudioPool").transform);
        gameAudioPool = new AudioPool(gameAudioPoolSize, gameAudioPrefab, new GameObject("GameAudioPool").transform);
        musicAudioPool = new AudioPool(musicAudioPoolSize, musicAudioPrefab, new GameObject("MusicAudioPool").transform);
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

    private void playAudio(AudioGroup audioGroup, AudioClip audioClip, Transform spawnTransform)
    {
        AudioPool audioPool;

        switch (audioGroup)
        {
            case AudioGroup.Menu:
                audioPool = menuAudioPool;
                break;
            case AudioGroup.Game:
                audioPool = gameAudioPool;
                break;
            case AudioGroup.Music:
                audioPool = musicAudioPool;
                break;
            default:
                return;
        }

        AudioSource audioSource = audioPool.getAudioSource();

        if (audioSource == null) 
            return;

        if (spawnTransform != null)
            audioSource.transform.position = spawnTransform.position;

        audioSource.clip = audioClip;
        audioSource.gameObject.SetActive(true);
        audioSource.Play();
        StartCoroutine(audioPool.returnAudioSource(audioSource));
    }

    private void setVolume(AudioGroup audioGroup, float volumeLevel)
    {
        string strAudioGroup;

        switch (audioGroup)
        {
            case AudioGroup.Master:
                strAudioGroup = "MasterVolume";
                break;
            case AudioGroup.Menu:
                strAudioGroup = "MenuFXVolume";
                break;
            case AudioGroup.Game:
                strAudioGroup = "GameFXVolume";
                break;
            case AudioGroup.Music:
                strAudioGroup = "MusicVolume";
                break;
            default:
                return;
        }

        audioMixer.SetFloat(strAudioGroup, Mathf.Log10(volumeLevel) * 20f);
    }
}
