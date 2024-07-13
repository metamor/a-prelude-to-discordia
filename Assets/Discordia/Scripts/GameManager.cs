using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;


// keeps track of the current game state such as the player name, current location, the player stats like servermanager, inventory manager
[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    [SerializeField]
    private Camera mainCamera = null;

    [SerializeField]
    private CinemachineCamera virtualPlayCamera = null;

    [SerializeField]
    private ServerManager serverManager = null;

    [SerializeField]
    private GameObject ui = null;

    // GameObject chat and userlist

    [SerializeField]
    private string currentScene = "";

    [SerializeField]
    private string currentServer = "";

    [SerializeField]
    private string currentLocation = "";

    // path of json saved file? call gameplay scene, then load scene which reads this file name and loads json to everything in gameplay and then load the correct location?

    // ui manager that handles the look of the ui and the camera size?

    // private json savedfile; this holds the ref to the json file and the managers in gameplay scene will load the data from this file if it is not null?

    // turn camera shake in the game settings file?

    // player name? or object
    // time and day? time and day system/manager?
    // current server (using server id instead of name)
    // current location (scene name); maybe the scene loader will call this to change the string?
    // public int serverBoost; the game can read this serverboost level right away so all npc/servers can get serverBoostlevel
    // bool paused?

    // public scenemanager?


    // or have a player class and put it in a list; can swap between (main?) characters; take control of another character perspective?


    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public Camera MainCamera
    {
        get
        {
            return mainCamera;
        }
    }

    public CinemachineCamera GetVirtualPlayCamera()
    {
        return virtualPlayCamera;
    }

    public void SetVirtualPlayCamera(CinemachineCamera virtualCam)
    {
        virtualPlayCamera = virtualCam;
    }

    public ServerManager GetServerManager()
    {
        return serverManager;
    }

    public GameObject GetUI()
    {
        return ui;
    }

    public void SetUI(GameObject gameUI)
    {
        ui = gameUI;
    }

    public void SetServerManager(ServerManager sm)
    {
        serverManager = sm;
    }

    public void ResetGameState()
    {
        currentScene = "";
        currentServer = "";
        currentLocation = "";
    }

    public void ShowUI()    ////   maybe ShowHUD and put this in a UI manager?  OR the menu scenes have their own ui interface?
    {
        if (ui != null)
        {
            ui.SetActive(true);
        }
        // hide chat and user list
    }

    public void HideUI()
    {
        if (ui != null)
        {
            ui.SetActive(false);
        }
        // hide chat and user list
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

    // void ResetGameManager
    // set all managers to null
    // reset all fields

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // function reset game state back to default
}
