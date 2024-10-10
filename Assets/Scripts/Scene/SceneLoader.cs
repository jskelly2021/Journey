using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance = null;

    [SerializeField] private Scenes bootScene;

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
        SceneEvents.OnLoadScene += loadScene;
        SceneEvents.OnUnloadScene += unloadScene;
        SceneEvents.OnSetSceneActive += setSceneActive;
    }
    private void OnDisable()
    {
        SceneEvents.OnLoadScene -= loadScene;
        SceneEvents.OnUnloadScene -= unloadScene;
        SceneEvents.OnSetSceneActive -= setSceneActive;
    }

    private void loadScene(Scenes sceneToLoad)
    {
        
        if (!SceneManager.GetSceneByName(sceneToLoad.GetSceneName()).IsValid())
            StartCoroutine(loadSceneAsync(sceneToLoad));
    }

    private void setSceneActive(Scenes sceneToSetActive)
    {
        if (!SceneManager.GetSceneByName(sceneToSetActive.GetSceneName()).IsValid())
            StartCoroutine(setSceneActiveAsync(sceneToSetActive));
        else
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToSetActive.GetSceneName()));
    }

    private void unloadScene(Scenes sceneToUnload)
    {
        if (SceneManager.GetSceneByName(sceneToUnload.GetSceneName()).isLoaded)
            StartCoroutine(unloadSceneAsync(sceneToUnload));
    }

    private IEnumerator loadSceneAsync(Scenes sceneToLoad)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad.GetSceneName(), LoadSceneMode.Additive);
         
        while (!asyncLoad.isDone)
            yield return null;
    }

    private IEnumerator unloadSceneAsync(Scenes sceneToUnload)
    {
        while (SceneManager.GetActiveScene().name == sceneToUnload.GetSceneName())
            yield return null;

        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(sceneToUnload.GetSceneName(), UnloadSceneOptions.None);
    }

    private IEnumerator setSceneActiveAsync(Scenes sceneToSetActive)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToSetActive.GetSceneName(), LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
            yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToSetActive.GetSceneName()));
    }
}
