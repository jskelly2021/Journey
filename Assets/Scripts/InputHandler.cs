using System;
using UnityEngine;

public abstract class InputHandler: MonoBehaviour
{
    public static event Action PauseAction;

    protected void Pause()
    {
        Debug.Log("Pausing Game from Input Handler");
        PauseAction?.Invoke();
    }
}
