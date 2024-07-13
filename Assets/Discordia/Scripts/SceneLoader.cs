using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Scene loader singleton.
    private static SceneLoader instance = null;

    private LoadingScreenController loadingScreen;
    private string loadingScreenName = string.Empty;

    private bool isLoading = false;

    private float progress = 0.0f;
    private float completedScenes = 0.0f;
    private float totalScenes = 0.0f;

    public static SceneLoader Instance
    {
        get
        {
            return instance;
        }
    }

    public LoadingScreenController LoadingScreen
    {
        set
        {
            loadingScreen = value;
        }
    }

    public string LoadingScreenName
    {
        get
        {
            return loadingScreenName;
        }
    }

    public bool IsLoading
    {
        get
        {
            return isLoading;
        }
    }

    public float Progress
    {
        get
        {
            return progress;
        }
    }

    // This method checks whether a scene is loaded.
    public bool IsSceneLoaded(string sceneName)
    {
        return SceneManager.GetSceneByName(sceneName).IsValid();
    }

    public string GetActiveScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void SetActiveScene(string sceneName)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }

    // Load a single scene additively.
    public void LoadScene(string sceneName, string activeSceneName)
    {
        // Don't load the scene if the scene loader is busy loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToLoad = new List<string>();
        scenesToLoad.Add(sceneName);

        StartCoroutine(LoadScenesSequenceCoroutine(scenesToLoad, activeSceneName));
    }

    // Load a single scene additively while using a loading screen.
    public void LoadScene(string sceneName, string activeSceneName, string loadingScreenName)
    {
        // Don't load the scene if the scene loader is busy loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToLoad = new List<string>();
        scenesToLoad.Add(sceneName);

        StartCoroutine(LoadScenesSequenceCoroutine(scenesToLoad, activeSceneName, loadingScreenName));
    }

    // Load multiple scenes additively.
    public void LoadScenes(List<string> scenesToLoad, string activeSceneName)
    {
        // Don't load the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        StartCoroutine(LoadScenesSequenceCoroutine(scenesToLoad, activeSceneName));
    }

    // Load multiple scenes additively while using a loading screen.
    public void LoadScenes(List<string> scenesToLoad, string activeSceneName, string loadingScreenName)
    {
        // Don't load the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        StartCoroutine(LoadScenesSequenceCoroutine(scenesToLoad, activeSceneName, loadingScreenName));
    }

    // Unload a single scene asynchronously.
    public void UnloadScene(string sceneName, string activeSceneName)
    {
        // Don't unload the scene if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToUnload = new List<string>();
        scenesToUnload.Add(sceneName);

        StartCoroutine(UnloadScenesSequenceCoroutine(scenesToUnload, activeSceneName));
    }

    // Unload a single scene asynchronously while using a loading screen.
    public void UnloadScene(string sceneName, string activeSceneName, string loadingScreenName)
    {
        // Don't unload the scene if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToUnload = new List<string>();
        scenesToUnload.Add(sceneName);

        StartCoroutine(UnloadScenesSequenceCoroutine(scenesToUnload, activeSceneName, loadingScreenName));
    }

    // Unload multiple scenes asynchronously.
    public void UnloadScenes(List<string> scenesToUnload, string activeSceneName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        StartCoroutine(UnloadScenesSequenceCoroutine(scenesToUnload, activeSceneName));
    }

    // Unload multiple scenes asynchronously while using a loading screen.
    public void UnloadScenes(List<string> scenesToUnload, string activeSceneName, string loadingScreenName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        StartCoroutine(UnloadScenesSequenceCoroutine(scenesToUnload, activeSceneName, loadingScreenName));
    }

    // Unload all scenes except certain scenes asynchronously.
    public void UnloadAllScenesExcept(List<string> scenesToKeep, string activeSceneName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        StartCoroutine(UnloadAllScenesExceptSequenceCoroutine(scenesToKeep, activeSceneName));
    }

    // Unload all scenes except certain scenes asynchronously while using a loading screen.
    public void UnloadAllScenesExcept(List<string> scenesToKeep, string activeSceneName, string loadingScreenName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        scenesToKeep.Add(loadingScreenName);

        StartCoroutine(UnloadAllScenesExceptSequenceCoroutine(scenesToKeep, activeSceneName, loadingScreenName));
    }

    // Unload a single scene asynchronously and then load a single scene additively.
    public void LoadSceneUnloadScene(string sceneToLoadName, string sceneToUnloadName, string activeSceneName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToLoad = new List<string>();
        scenesToLoad.Add(sceneToLoadName);

        List<string> scenesToUnload = new List<string>();
        scenesToUnload.Add(sceneToUnloadName);

        StartCoroutine(LoadScenesUnloadScenesSequenceCoroutine(scenesToLoad, scenesToUnload, activeSceneName));
    }

    // Unload a single scene asynchronously and then load a single scene additively while using a loading screen.
    public void LoadSceneUnloadScene(string sceneToLoadName, string sceneToUnloadName, string activeSceneName, string loadingScreenName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToLoad = new List<string>();
        scenesToLoad.Add(sceneToLoadName);

        List<string> scenesToUnload = new List<string>();
        scenesToUnload.Add(sceneToUnloadName);

        StartCoroutine(LoadScenesUnloadScenesSequenceCoroutine(scenesToLoad, scenesToUnload, activeSceneName, loadingScreenName));
    }

    // Unload multiple scenes asynchronously and then load multiple scenes additively.
    public void LoadScenesUnloadScenes(List<string> scenesToLoad, List<string> scenesToUnload, string activeSceneName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        StartCoroutine(LoadScenesUnloadScenesSequenceCoroutine(scenesToLoad, scenesToUnload, activeSceneName));
    }

    // Unload multiple scenes asynchronously and then load multiple scenes additively while using a loading screen.
    public void LoadScenesUnloadScenes(List<string> scenesToLoad, List<string> scenesToUnload, string activeSceneName, string loadingScreenName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        StartCoroutine(LoadScenesUnloadScenesSequenceCoroutine(scenesToLoad, scenesToUnload, activeSceneName, loadingScreenName));
    }

    // Unload all scenes except a certain scene asynchronously and load a new scene additively.
    public void LoadSceneUnloadAllScenesExcept(string sceneToLoadName, string sceneToKeepName, string activeSceneName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToLoad = new List<string>();
        scenesToLoad.Add(sceneToLoadName);

        List<string> scenesToKeep = new List<string>();
        scenesToLoad.Add(sceneToKeepName);

        StartCoroutine(LoadScenesUnloadAllScenesExceptSequenceCoroutine(scenesToLoad, scenesToKeep, activeSceneName));
    }

    // Unload all scenes except a certain scene asynchronously and then load a new scene additively while using a loading screen.
    public void LoadSceneUnloadAllScenesExcept(string sceneToLoadName, string sceneToKeepName, string activeSceneName, string loadingScreenName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToLoad = new List<string>();
        scenesToLoad.Add(sceneToLoadName);

        List<string> scenesToKeep = new List<string>();
        scenesToKeep.Add(sceneToKeepName);
        scenesToKeep.Add(loadingScreenName);

        StartCoroutine(LoadScenesUnloadAllScenesExceptSequenceCoroutine(scenesToLoad, scenesToKeep, activeSceneName, loadingScreenName));
    }

    // Unload all scenes except certain scenes asynchronously and load a new scene additively.
    public void LoadSceneUnloadAllScenesExcept(string sceneToLoadName, List<string> scenesToKeep, string activeSceneName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToLoad = new List<string>();
        scenesToLoad.Add(sceneToLoadName);

        StartCoroutine(LoadScenesUnloadAllScenesExceptSequenceCoroutine(scenesToLoad, scenesToKeep, activeSceneName));
    }

    // Unload all scenes except certain scenes asynchronously and then load a new scene additively while using a loading screen.
    public void LoadSceneUnloadAllScenesExcept(string sceneToLoadName, List<string> scenesToKeep, string activeSceneName, string loadingScreenName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToLoad = new List<string>();
        scenesToLoad.Add(sceneToLoadName);

        scenesToKeep.Add(loadingScreenName);

        StartCoroutine(LoadScenesUnloadAllScenesExceptSequenceCoroutine(scenesToLoad, scenesToKeep, activeSceneName, loadingScreenName));
    }

    // Unload all scenes except a certain scene asynchronously and load new scenes additively.
    public void LoadScenesUnloadAllScenesExcept(List<string> scenesToLoad, string sceneToKeepName, string activeSceneName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToKeep = new List<string>();
        scenesToKeep.Add(sceneToKeepName);

        StartCoroutine(LoadScenesUnloadAllScenesExceptSequenceCoroutine(scenesToLoad, scenesToKeep, activeSceneName));
    }

    // Unload all scenes except a certain scene asynchronously and then load new scenes additively while using a loading screen.
    public void LoadScenesUnloadAllScenesExcept(List<string> scenesToLoad, string sceneToKeepName, string activeSceneName, string loadingScreenName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        List<string> scenesToKeep = new List<string>();
        scenesToKeep.Add(sceneToKeepName);
        scenesToKeep.Add(loadingScreenName);

        StartCoroutine(LoadScenesUnloadAllScenesExceptSequenceCoroutine(scenesToLoad, scenesToKeep, activeSceneName, loadingScreenName));
    }

    // Unload all scenes except certain scenes asynchronously and load new scenes additively.
    public void LoadScenesUnloadAllScenesExcept(List<string> scenesToLoad, List<string> scenesToKeep, string activeSceneName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        StartCoroutine(LoadScenesUnloadAllScenesExceptSequenceCoroutine(scenesToLoad, scenesToKeep, activeSceneName));
    }

    // Unload all scenes except certain scenes asynchronously and then load new scenes additively while using a loading screen.
    public void LoadScenesUnloadAllScenesExcept(List<string> scenesToLoad, List<string> scenesToKeep, string activeSceneName, string loadingScreenName)
    {
        // Don't unload the scenes if the scene loader is still in the process of loading or unloading another scene.
        if (isLoading)
        {
            return;
        }

        scenesToKeep.Add(loadingScreenName);

        StartCoroutine(LoadScenesUnloadAllScenesExceptSequenceCoroutine(scenesToLoad, scenesToKeep, activeSceneName, loadingScreenName));
    }

    // Show the loading screen without loading or unloading any scenes.
    public void ShowLoadingScreen(string loadingScreenName)
    {
        // Don't load the loading screen if the scene loader is busy loading or unloading another scene. Don't load if a loading screen is already showing.
        if (isLoading || !string.IsNullOrEmpty(this.loadingScreenName))
        {
            return;
        }

        StartCoroutine(ShowLoadingScreenSequenceCoroutine(loadingScreenName));
    }

    // Hide the loading screen without loading or unloading any scenes.
    public void HideLoadingScreen(string loadingScreenName)
    {
        // Don't load the loading screen if the scene loader is busy loading or unloading another scene.
        if (isLoading || string.IsNullOrEmpty(this.loadingScreenName))
        {
            return;
        }

        StartCoroutine(HideLoadingScreenSequenceCoroutine(loadingScreenName));
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private IEnumerator LoadScenesCoroutine(List<string> scenesToLoad)
    {
        AsyncOperation asyncOperation;

        // Load each scene asynchronously. The scenes are loaded in order of their list index. This is important for scenes that may need to be loaded in a specific order.
        for (int i = 0; i < scenesToLoad.Count; i++)
        {
            asyncOperation = SceneManager.LoadSceneAsync(scenesToLoad[i], LoadSceneMode.Additive);
            asyncOperation.allowSceneActivation = true;

            // Update the progress value to show how much of the loading process has been completed.
            while (!asyncOperation.isDone)
            {
                // Update the progress value after each frame.
                progress = (completedScenes + asyncOperation.progress) / totalScenes;

                yield return null;
            }

            completedScenes = completedScenes + 1.0f;
            progress = completedScenes / totalScenes;
        }

        asyncOperation = null;
    }

    private IEnumerator UnloadScenesCoroutine(List<string> scenesToUnload)
    {
        AsyncOperation asyncOperation;

        // Unload each scene asynchronously. The scenes are unloaded in order of their index in the list. Important for scenes that may need to be unloaded in a specific order.
        for (int i = 0; i < scenesToUnload.Count; i++)
        {
            asyncOperation = SceneManager.UnloadSceneAsync(scenesToUnload[i]);
            asyncOperation.allowSceneActivation = true;

            // Update the progress value to show how much of the unloading process has been completed.
            while (!asyncOperation.isDone)
            {
                // Update the progress value after each frame.
                progress = (completedScenes + asyncOperation.progress) / totalScenes;

                yield return null;
            }

            completedScenes = completedScenes + 1.0f;
            progress = completedScenes / totalScenes;
        }

        asyncOperation = null;
    }

    private IEnumerator UnloadAllScenesExceptCoroutine(List<string> scenesToKeep)
    {
        AsyncOperation asyncOperation;
        Scene scene;
        bool keepScene;

        // Go through all the loaded scenes to see if the scene loader should unload or keep the scene.
        for (int i = SceneManager.sceneCount - 1; i >= 0; i--)
        {
            scene = SceneManager.GetSceneAt(i);
            keepScene = false;

            // Go through the list of scenes to check if the scene should be kept loaded.
            for (int j = 0; j < scenesToKeep.Count; j++)
            {
                if (scene.name == scenesToKeep[j])
                {
                    keepScene = true;
                    break;
                }
            }

            if (keepScene == false)
            {
                asyncOperation = SceneManager.UnloadSceneAsync(scene);
                asyncOperation.allowSceneActivation = true;

                // Update the progress value to show how much of the unloading process has been completed.
                while (!asyncOperation.isDone)
                {
                    // Update the progress value after each frame.
                    progress = (completedScenes + asyncOperation.progress) / totalScenes;

                    yield return null;
                }
            }

            completedScenes = completedScenes + 1.0f;
            progress = completedScenes / totalScenes;
        }

        asyncOperation = null;
    }

    // Coroutine that loads the loading screen. This is different from loading a scene the normal way as we don't want the loading screen to count towards the progress percent.
    private IEnumerator LoadLoadingScreenCoroutine(string loadingScreenName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(loadingScreenName, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = true;

        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        asyncOperation = null;
    }

    private IEnumerator UnloadLoadingScreenCoroutine(string loadingScreenName)
    {
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(loadingScreenName);
        asyncOperation.allowSceneActivation = true;

        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        asyncOperation = null;
    }

    private IEnumerator LoadScenesSequenceCoroutine(List<string> scenesToLoad, string activeSceneName)
    {
        isLoading = true;

        loadingScreen = null;
        this.loadingScreenName = string.Empty;

        progress = 0.0f;
        completedScenes = 0.0f;
        totalScenes = (float)scenesToLoad.Count;

        yield return LoadScenesCoroutine(scenesToLoad);
        SetActiveScene(activeSceneName);

        isLoading = false;
    }

    private IEnumerator LoadScenesSequenceCoroutine(List<string> scenesToLoad, string activeSceneName, string loadingScreenName)
    {
        isLoading = true;

        this.loadingScreenName = loadingScreenName;

        progress = 0.0f;
        completedScenes = 0.0f;
        totalScenes = (float)scenesToLoad.Count;

        yield return LoadLoadingScreenCoroutine(loadingScreenName);
        loadingScreen.ShowLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        yield return LoadScenesCoroutine(scenesToLoad);
        SetActiveScene(activeSceneName);

        loadingScreen.HideLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        loadingScreen = null;
        yield return UnloadLoadingScreenCoroutine(loadingScreenName);

        this.loadingScreenName = string.Empty;

        isLoading = false;
    }

    private IEnumerator UnloadScenesSequenceCoroutine(List<string> scenesToUnload, string activeSceneName)
    {
        isLoading = true;

        loadingScreen = null;
        this.loadingScreenName = string.Empty;

        progress = 0.0f;
        completedScenes = 0.0f;
        totalScenes = (float)scenesToUnload.Count;

        SetActiveScene(activeSceneName);
        yield return UnloadScenesCoroutine(scenesToUnload);

        isLoading = false;
    }

    private IEnumerator UnloadScenesSequenceCoroutine(List<string> scenesToUnload, string activeSceneName, string loadingScreenName)
    {
        isLoading = true;

        this.loadingScreenName = loadingScreenName;

        progress = 0.0f;
        completedScenes = 0.0f;
        totalScenes = (float)scenesToUnload.Count;

        yield return LoadLoadingScreenCoroutine(loadingScreenName);
        loadingScreen.ShowLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        yield return UnloadScenesCoroutine(scenesToUnload);
        SetActiveScene(activeSceneName);

        loadingScreen.HideLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        loadingScreen = null;
        yield return UnloadLoadingScreenCoroutine(loadingScreenName);

        this.loadingScreenName = string.Empty;

        isLoading = false;
    }

    // Upload all scenes except certain scenes.
    private IEnumerator UnloadAllScenesExceptSequenceCoroutine(List<string> scenesToKeep, string activeSceneName)
    {
        isLoading = true;

        progress = 0.0f;
        completedScenes = 0.0f;
        totalScenes = (float)SceneManager.sceneCount;

        SetActiveScene(activeSceneName);
        yield return UnloadAllScenesExceptCoroutine(scenesToKeep);

        loadingScreen = null;
        this.loadingScreenName = string.Empty;

        isLoading = false;
    }

    // Upload all scenes except certain scenes and use a loading screen.
    private IEnumerator UnloadAllScenesExceptSequenceCoroutine(List<string> scenesToKeep, string activeSceneName, string loadingScreenName)
    {
        isLoading = true;

        this.loadingScreenName = loadingScreenName;

        progress = 0.0f;
        completedScenes = 0.0f;
        totalScenes = (float)SceneManager.sceneCount;

        yield return LoadLoadingScreenCoroutine(loadingScreenName);
        loadingScreen.ShowLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        SetActiveScene(activeSceneName);
        yield return UnloadAllScenesExceptCoroutine(scenesToKeep);

        loadingScreen.HideLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        loadingScreen = null;
        yield return UnloadLoadingScreenCoroutine(loadingScreenName);

        this.loadingScreenName = string.Empty;

        isLoading = false;
    }

    private IEnumerator LoadScenesUnloadScenesSequenceCoroutine(List<string> scenesToLoad, List<string> scenesToUnload, string activeSceneName)
    {
        isLoading = true;

        progress = 0.0f;
        completedScenes = 0.0f;
        totalScenes = (float)scenesToLoad.Count + (float)scenesToUnload.Count;

        yield return UnloadScenesCoroutine(scenesToUnload);
        yield return LoadScenesCoroutine(scenesToLoad);
        SetActiveScene(activeSceneName);

        loadingScreen = null;
        this.loadingScreenName = string.Empty;

        isLoading = false;
    }

    private IEnumerator LoadScenesUnloadScenesSequenceCoroutine(List<string> scenesToLoad, List<string> scenesToUnload, string activeSceneName, string loadingScreenName)
    {
        isLoading = true;

        this.loadingScreenName = loadingScreenName;

        progress = 0.0f;
        completedScenes = 0.0f;
        totalScenes = (float)scenesToLoad.Count + (float)scenesToUnload.Count;

        yield return LoadLoadingScreenCoroutine(loadingScreenName);
        loadingScreen.ShowLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        yield return UnloadScenesCoroutine(scenesToUnload);
        yield return LoadScenesCoroutine(scenesToLoad);
        SetActiveScene(activeSceneName);

        loadingScreen.HideLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        loadingScreen = null;
        yield return UnloadLoadingScreenCoroutine(loadingScreenName);

        this.loadingScreenName = string.Empty;

        isLoading = false;
    }

    // Upload all scenes except certain scenes and load new scenes.
    private IEnumerator LoadScenesUnloadAllScenesExceptSequenceCoroutine(List<string> scenesToLoad, List<string> scenesToKeep, string activeSceneName)
    {
        isLoading = true;

        progress = 0.0f;
        completedScenes = 0.0f;
        totalScenes = (float)SceneManager.sceneCount + (float)scenesToLoad.Count;

        // For the case where we want the active scene to be one of the scenes to be kept loaded.
        if (SceneManager.GetSceneByName(activeSceneName).IsValid())
        {
            SetActiveScene(activeSceneName);
        }

        yield return UnloadAllScenesExceptCoroutine(scenesToKeep);
        yield return LoadScenesCoroutine(scenesToLoad);
        SetActiveScene(activeSceneName);

        loadingScreen = null;
        this.loadingScreenName = string.Empty;

        isLoading = false;
    }

    // Upload all scenes except certain scenes, load new scenes, and use a loading screen.
    private IEnumerator LoadScenesUnloadAllScenesExceptSequenceCoroutine(List<string> scenesToLoad, List<string> scenesToKeep, string activeSceneName, string loadingScreenName)
    {
        isLoading = true;

        this.loadingScreenName = loadingScreenName;

        progress = 0.0f;
        completedScenes = 0.0f;
        totalScenes = (float)SceneManager.sceneCount + (float)scenesToLoad.Count;

        yield return LoadLoadingScreenCoroutine(loadingScreenName);
        loadingScreen.ShowLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        yield return UnloadAllScenesExceptCoroutine(scenesToKeep);
        yield return LoadScenesCoroutine(scenesToLoad);
        SetActiveScene(activeSceneName);

        loadingScreen.HideLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        loadingScreen = null;
        yield return UnloadLoadingScreenCoroutine(loadingScreenName);

        this.loadingScreenName = string.Empty;

        isLoading = false;
    }

    public IEnumerator ShowLoadingScreenSequenceCoroutine(string loadingScreenName)
    {
        isLoading = true;

        this.loadingScreenName = loadingScreenName;

        progress = 0.0f;
        completedScenes = 0.0f;
        totalScenes = 0.0f;

        yield return LoadLoadingScreenCoroutine(loadingScreenName);
        loadingScreen.ShowLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        isLoading = false;
    }

    public IEnumerator HideLoadingScreenSequenceCoroutine(string loadingScreenName)
    {
        isLoading = true;

        progress = 1.0f;
        completedScenes = 0.0f;
        totalScenes = 0.0f;

        loadingScreen.HideLoadingScreen();

        while (loadingScreen.IsTransitioning == true)
        {
            yield return new WaitForEndOfFrame();
        }

        loadingScreen = null;
        yield return UnloadLoadingScreenCoroutine(loadingScreenName);

        this.loadingScreenName = string.Empty;

        isLoading = false;
    }
}