using UnityEngine;
using Eflatun.SceneReference;

public class SceneController : MonoBehaviour
{
    private SceneLoader sceneLoader;
    [SerializeField] private SceneReference thisScene;
    [SerializeField] private SceneReference nextScene;

    private void Awake()
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();   
    }

    public void loadScene()
    {
        sceneLoader.loadScene(nextScene);
    }

    public void unloadScene()
    {
        sceneLoader.unloadScene(thisScene);
    }
}
