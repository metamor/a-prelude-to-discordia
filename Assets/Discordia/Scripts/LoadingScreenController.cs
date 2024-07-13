using System.Collections;
using UnityEngine;

public class LoadingScreenController : MonoBehaviour
{
    // The content of the loading screen.
    [SerializeField]
    private GameObject content;

    [SerializeField]
    private GameObject progressBar;

    [SerializeField]
    private bool useProgressBar;

    // Text that notifies the player to press the button to move pass the loading screen.
    [SerializeField]
    private GameObject pressButtonNotification;

    [SerializeField]
    private Animator sceneTransitionAnimation;

    // Should a scene transition effect be used at the beginning and end of the loading screen.
    [SerializeField]
    private bool useSceneTransition;

    private bool isTransitioning = false;

    public bool UseProgressBar
    {
        set
        {
            useProgressBar = value;
        }
    }

    public bool UseSceneTransition
    {
        set
        {
            useSceneTransition = value;
        }
    }

    public bool IsTransitioning
    {
        get
        {
            return isTransitioning;
        }
    }

    // The controller will start its own coroutine to show the loading screen.
    public void ShowLoadingScreen()
    {
        StartCoroutine(ShowLoadingScreenCoroutine());
    }

    // The controller will start its own coroutine to show the loading screen.
    public void HideLoadingScreen()
    {
        StartCoroutine(HideLoadingScreenCoroutine());
    }

    public void showPressButtonNotification()
    {
        pressButtonNotification.SetActive(true);
    }

    public void hidePressButtonNotification()
    {
        pressButtonNotification.SetActive(false);
    }

    private void Awake()
    {
        // Add the loading screen controller to the scene loader so it can access the loading screen when changing scenes.
        SceneLoader.Instance.LoadingScreen = this;
    }

    private IEnumerator ShowLoadingScreenCoroutine()
    {
        isTransitioning = true;

        if (progressBar != null)
        {
            progressBar.SetActive(useProgressBar);
        }

        if (useSceneTransition)
        {
            sceneTransitionAnimation.Play("SceneTransitionIn");

            while (!sceneTransitionAnimation.GetCurrentAnimatorStateInfo(0).IsName("SceneTransitionInDone"))
            {
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            if (sceneTransitionAnimation != null)
            {
                sceneTransitionAnimation.enabled = false;
            }
            
            // Set the contents of the loading screen to active since the transition isn't there to set the content to active.
            content.SetActive(true);
        }

        isTransitioning = false;
    }

    private IEnumerator HideLoadingScreenCoroutine()
    {
        isTransitioning = true;

        if (useSceneTransition)
        {
            sceneTransitionAnimation.Play("SceneTransitionOut");

            while (!sceneTransitionAnimation.GetCurrentAnimatorStateInfo(0).IsName("SceneTransitionOutDone"))
            {
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            // Set the contents of the loading screen to inactive since the transition isn't there to set the content to inactive.
            content.SetActive(false);
        }

        isTransitioning = false;
    }
}
