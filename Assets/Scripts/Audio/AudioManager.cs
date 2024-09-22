using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioManager instance;
    [SerializeField] private AudioSource audioSourcePrefab;

    public AudioManager Instace { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    private void OnEnable()
    {
        AudioEventManager.OnPlayAudio += playAudio;
    }
    private void OnDisable()
    {
        AudioEventManager.OnPlayAudio -= playAudio;
    }

    private void playAudio(AudioClip audioClip)
    {
        Debug.Log("Playing audioClip");
        AudioSource audioSource = Instantiate(audioSourcePrefab);
        audioSource.transform.parent = gameObject.transform;
        audioSource.clip = audioClip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioClip.length);
    }
}
