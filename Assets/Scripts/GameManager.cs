using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        StoreController.Init();
        PauseController.Init();
        TransitionController.Init();
    }
}
