using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance = null;

    public SceneLoader Instance
    {
        get
        {
            if (instance == null)
                instance = new SceneLoader();
            return instance;
        }
    }

    public void loadScene(string sceneName)
    {
        Scene sceneToLoad = SceneManager.GetSceneByName(sceneName);

        if (!sceneToLoad.IsValid())
            StartCoroutine(loadSceneAsync(sceneName));
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
