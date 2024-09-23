using System;
using UnityEngine;

public class QuitController : MonoBehaviour
{
    public static event Action QuitGame;

    public void quitGame() => QuitGame?.Invoke();
}
