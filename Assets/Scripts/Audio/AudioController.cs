using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    public void playSound()
    {
        audioSource.Play();
    }
}
