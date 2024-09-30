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
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        loadScene(bootScene);
    }

    private void OnEnable()
    {
        SceneEventManager.OnLoadScene += loadScene;
        SceneEventManager.OnUnloadScene += unloadScene;
        SceneEventManager.OnSetSceneActive += setSceneActive;
    }
    private void OnDisable()
    {
        SceneEventManager.OnLoadScene -= loadScene;
        SceneEventManager.OnUnloadScene -= unloadScene;
        SceneEventManager.OnSetSceneActive -= setSceneActive;
    }

    private void loadScene(SceneReference sceneToLoad)
    {
        if (!SceneManager.GetSceneByPath(sceneToLoad.Path).IsValid())
            StartCoroutine(loadSceneAsync(sceneToLoad));
    }

    private void setSceneActive(SceneReference sceneToSetActive)
    {
        if (!SceneManager.GetSceneByPath(sceneToSetActive.Path).IsValid())
            StartCoroutine(setSceneActiveAsync(sceneToSetActive));
        else
            SceneManager.SetActiveScene(SceneManager.GetSceneByPath(sceneToSetActive.Path));
    }

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
