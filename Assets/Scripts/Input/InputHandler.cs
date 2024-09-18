using System;
using UnityEngine;

public abstract class InputHandler: MonoBehaviour
{
    public static event Action PauseAction;
    public static event Action ResumeAction;

    protected void Pause()
    {
        PauseAction?.Invoke();
    }

    protected void Resume()
    {
        ResumeAction?.Invoke();
    }
}
