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
        StartCoroutine(loadSceneAsync(sceneName));
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

}
