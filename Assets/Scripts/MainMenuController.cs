using System.Xml.Serialization;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private void OnEnable()
    {
        AudioEventManager.playAudio(AudioGroup.Music, audioClip, null);
    }

    private void OnDisable()
    {
        AudioEventManager.stopAllAudioInGroup(AudioGroup.Music);
    }
}
