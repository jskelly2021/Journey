using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioManager instance;

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
        
    }
    private void OnDisable()
    {
        
    }

}
