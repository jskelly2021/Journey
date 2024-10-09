using System;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public static event Action<UICanvases, bool> OnEnableCanvas;

    public static void EnableCanvas(UICanvases canvas, bool setActive) => OnEnableCanvas?.Invoke(canvas, setActive);
}
