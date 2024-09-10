using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public GameManager Instance 
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }
}
