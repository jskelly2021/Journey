using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance = null;

    [SerializeField] public SceneReference bootScene;

    public SceneLoader Instance
    {
        get
        {
            if (instance == null)
                instance = new SceneLoader();
            return instance;
        }
    }

    private void Awake()
    {
        loadScene(bootScene);
    }

    public void loadScene(SceneReference sceneToLoad)
    {
        if (!SceneManager.GetSceneByPath(sceneToLoad.Path).IsValid())
            StartCoroutine(loadSceneAsync(sceneToLoad.Name));
    }

    public void unloadScene(string sceneName)
    {
        StartCoroutine(unloadSceneAsync(sceneName));
    }

    private IEnumerator loadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Debug.Log(SceneManager.GetActiveScene().name);

        while (!asyncLoad.isDone)
            yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    private IEnumerator unloadSceneAsync(string sceneName)
    {
        while (SceneManager.GetActiveScene().name == sceneName)
            yield return null;

        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.None);
        Debug.Log(sceneName + " is unloaded");
    }
}
