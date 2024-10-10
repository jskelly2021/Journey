using System;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public static event Action<UICanvases, bool> OnEnableCanvas;
    public static event Action OnDisableAllCanvases;

    public static void EnableCanvas(UICanvases canvas, bool setActive) => OnEnableCanvas?.Invoke(canvas, setActive);
    public static void DisableAllCanvases() => OnDisableAllCanvases?.Invoke();
}
