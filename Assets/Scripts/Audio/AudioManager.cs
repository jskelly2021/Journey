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

        menuAudioPool = new AudioPool(menuAudioPoolSize, menuAudioPrefab, gameObject.transform);
        gameAudioPool = new AudioPool(gameAudioPoolSize, gameAudioPrefab, gameObject.transform);
        musicAudioPool = new AudioPool(musicAudioPoolSize, musicAudioPrefab, gameObject.transform);
    }

    private void OnEnable()
    {
        AudioEventManager.OnPlayMenuAudio += playMenuAudio;
        AudioEventManager.OnPlayGameAudio += playGameAudio;
        AudioEventManager.OnPlayMusicAudio += playMusicAudio;
        AudioEventManager.OnSetVolume += setVolume;
    }
    private void OnDisable()
    {
        AudioEventManager.OnPlayMenuAudio -= playMenuAudio;
        AudioEventManager.OnPlayGameAudio -= playGameAudio;
        AudioEventManager.OnPlayMusicAudio -= playMusicAudio;
        AudioEventManager.OnSetVolume -= setVolume;
    }

    private void playMenuAudio(AudioClip audioClip) => playAudio(menuAudioPool, audioClip);
    private void playGameAudio(AudioClip audioClip) => playAudio(gameAudioPool, audioClip);
    private void playMusicAudio(AudioClip audioClip) => playAudio(musicAudioPool, audioClip);

    private void playAudio(AudioPool audioPool, AudioClip audioClip)
    {
        AudioSource audioSource = audioPool.getAudioSource();
        audioSource.clip = audioClip;
        audioSource.gameObject.SetActive(true);
        audioSource.Play();
        StartCoroutine(audioPool.returnAudioSource(audioSource));
    }

    private void setVolume(string audioGroup, float volumeLevel)
    {
        audioMixer.SetFloat(audioGroup, Mathf.Log10(volumeLevel) * 20f);
    }
}
