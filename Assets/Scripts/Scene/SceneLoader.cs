using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance = null;

    [SerializeField] private SceneReference bootScene;

    public static SceneLoader Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        loadScene(bootScene);
    }

    private void OnEnable()
    {
        SceneController.LoadScene += loadScene;
        SceneController.UnloadScene += unloadScene;
        SceneController.SetSceneActive += setSceneActive;
    }
    private void OnDisable()
    {
        SceneController.LoadScene -= loadScene;
        SceneController.UnloadScene -= unloadScene;
        SceneController.SetSceneActive -= setSceneActive;
    }

    /// <summary>
    /// Asynchronously loads the scene referenced by <paramref name="sceneToLoad"/> if not already loaded.
    /// </summary>
    /// <param name="sceneToLoad"></param>
    private void loadScene(SceneReference sceneToLoad)
    {
        if (!SceneManager.GetSceneByPath(sceneToLoad.Path).IsValid())
            StartCoroutine(loadSceneAsync(sceneToLoad));
    }

    /// <summary>
    /// If scene referenced by <paramref name="sceneToSetActive"/> is loaded, sets it as the active scene. 
    /// Otherwise, asynchronously loads the scene referenced by <paramref name="sceneToSetActive"/> and sets it as the active scene.
    /// </summary>
    /// <param name="sceneToSetActive"></param>
    private void setSceneActive(SceneReference sceneToSetActive)
    {
        if (!SceneManager.GetSceneByPath(sceneToSetActive.Path).IsValid())
            StartCoroutine(setSceneActiveAsync(sceneToSetActive));
        else
            SceneManager.SetActiveScene(SceneManager.GetSceneByPath(sceneToSetActive.Path));
    }

    /// <summary>
    /// Aysnchronously unloads the scene referenced by <paramref name="sceneToUnload"/> only if it is not the active scene. 
    /// Otherwise, waits until <paramref name="sceneToUnload"/> is not the active scene and then unloads it.
    /// </summary>
    /// <param name="sceneToUnload"></param>
    private void unloadScene(SceneReference sceneToUnload)
    {
        StartCoroutine(unloadSceneAsync(sceneToUnload));
    }

    private IEnumerator loadSceneAsync(SceneReference sceneToLoad)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad.Path, LoadSceneMode.Additive);
         
        while (!asyncLoad.isDone)
            yield return null;
    }

    private IEnumerator unloadSceneAsync(SceneReference sceneToUnload)
    {
        while (SceneManager.GetActiveScene().path == sceneToUnload.Path)
            yield return null;

        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(sceneToUnload.Path, UnloadSceneOptions.None);
    }

    private IEnumerator setSceneActiveAsync(SceneReference sceneToSetActive)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToSetActive.Path, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
            yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneByPath(sceneToSetActive.Path));
    }
}
