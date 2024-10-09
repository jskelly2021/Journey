using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : Button
{
    [SerializeField] private AudioClip clickSound;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (clickSound != null )
            AudioEvents.PlayAudio(AudioGroup.Menu, clickSound, null);
    }
}
