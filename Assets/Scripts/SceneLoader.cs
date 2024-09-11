using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance = null;

    [SerializeField] private SceneReference bootScene;

    public SceneLoader Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        loadScene(bootScene);
    }

    public void loadScene(SceneReference sceneToLoad)
    {
        if (!SceneManager.GetSceneByPath(sceneToLoad.Path).IsValid())
            StartCoroutine(loadSceneAsync(sceneToLoad));
    }

    public void unloadScene(SceneReference sceneToUnload)
    {
        StartCoroutine(unloadSceneAsync(sceneToUnload));
    }

    private IEnumerator loadSceneAsync(SceneReference sceneToLoad)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad.Path, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
            yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneByPath(sceneToLoad.Path));
    }

    private IEnumerator unloadSceneAsync(SceneReference sceneToUnload)
    {
        while (SceneManager.GetActiveScene().path == sceneToUnload.Path)
            yield return null;

        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(sceneToUnload.Path, UnloadSceneOptions.None);
    }
}
