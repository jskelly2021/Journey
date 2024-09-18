using System;
using UnityEngine;

public abstract class InputHandler: MonoBehaviour
{
    public static event Action PauseAction;

    protected void Pause()
    {
        PauseAction?.Invoke();
    }
}
