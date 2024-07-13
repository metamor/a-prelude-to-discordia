using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    //[SerializeField]
    //private DatabaseSO characterDatabase;

    //[SerializeField]
    //private DatabaseSO itemDatabase;

    [SerializeField]
    // The scriptable object database that has a list of all the server data scriptable object stored.
    private DatabaseSO serverDatabase;

    void Awake()
    {
        // Take all the scriptable object data and builds a database for each data type. A server database from the server data, an item database from the item data, etc.
        InitializeDatabase();
    }

    private void Start()
    {
        StartCoroutine(BootstrapSequenceCoroutine());
    }

    private void InitializeDatabase()
    {
        serverDatabase.CreateDatabase();
    }

    // make sure loadingscreen and core isn't already loaded?

    public IEnumerator BootstrapSequenceCoroutine()
    {
        // Check if the core scene isn't already loaded as there should only ever be one core scene ever loaded.
        if (SceneManager.GetSceneByName("Core").IsValid() == false)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Core", LoadSceneMode.Additive);
            asyncOperation.allowSceneActivation = true;

            // Wait for the core scene to load additively.
            while (!asyncOperation.isDone)
            {
                yield return null;
            }

            // Load the title scene. This will also unload the bootstrapper scene.
            SceneLoader.Instance.LoadSceneUnloadAllScenesExcept("Title", "Core", "Title", "DiscordLoadingScreen");
        }
    }
}
