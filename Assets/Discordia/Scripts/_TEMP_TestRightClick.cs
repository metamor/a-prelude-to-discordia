using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestRightClick : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject goToInstantiate;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(name);
        //exampleSO.testName();
    }

    private void OnMouseDown()
    {
        //Debug.Log("Left Click from " + this.name);
        //SceneLoader.Instance.ShowLoadingScreen("DiscordLoadingScreen");
        //SceneLoader.Instance.LoadScene("Tutorial2", "Tutorial2", "DiscordLoadingScreen");

        //List<string> scenesToLoad = new List<string> { "Tutorial2", "Tutorial2", "Tutorial2", "Tutorial2", "Tutorial2", "Tutorial2", "Tutorial2" };
        //SceneLoader.Instance.LoadScenes(scenesToLoad, "Tutorial2", "DiscordLoadingScreen");

        List<string> scenesToLoad = new List<string> { "Tutorial2", "Tutorial2", "Tutorial2", "Tutorial2", "Tutorial2", "Tutorial2", "Tutorial2" };
        List<string> scenesToKeep = new List<string> { "Core", "Tutorial1" };
        SceneLoader.Instance.LoadScenesUnloadAllScenesExcept(scenesToLoad, scenesToKeep, "Tutorial2", "DiscordLoadingScreen");

        Debug.Log("Left Click 2 !");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //SceneLoader.Instance.HideLoadingScreen("DiscordLoadingScreen");
            //SceneLoader.Instance.UnloadScene("Tutorial2", "Tutorial1", "DiscordLoadingScreen");

            //List<string> scenesToKeep = new List<string> { "Tutorial1" };
            //SceneLoader.Instance.UnloadAllScenesExcept(scenesToKeep, "Tutorial1", "DiscordLoadingScreen");

            Debug.Log("Right Click 2!");
        }

        if (Input.anyKeyDown)
        {
            Debug.Log("Test Any Key");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //SceneLoader.Instance.ShowLoadingScreen("DiscordLoadingScreen");
            //Debug.Log("Left Click");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Debug.Log("Right Click");
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Instantiate(goToInstantiate, this.transform);
            //Debug.Log("Middle Click");
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output the name of the GameObject that is being clicked
        //Debug.Log(name + "Game Object Click in Progress");
    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        //Debug.Log(name + "No longer being clicked");
    }

    public void SendToDebugLog()
    {
        Debug.Log("Send to debug log!");
    }
}
