using System;
using UnityEngine;

public abstract class InputHandler: MonoBehaviour
{
    public static event Action PauseAction;

    protected void Pause()
    {
        Debug.Log(" Pause Invoked");
        PauseAction?.Invoke();
    }
}
