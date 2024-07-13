using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewServer", menuName = "Scriptable Object/Server")]
public class ServerDataSO : DataSO
{
    [SerializeField]
    // The server display name can have the same name as another server such as in the case where the server is a future version of itself.
    private string displayName;

    [SerializeField]
    // The server type. Community like raiding?, Verified means official, Partnered at best; Story, Side, Home, Normal, Raid, Event, User, Friend.
    private string serverType;

    [SerializeField]
    // A description of the server.
    private string description;

    [SerializeField]
    // The default level the server starts out at. The default for most servers is 0.
    private int defaultLevel;

    [SerializeField]
    // The maximum level the server can have. The server level cap is 4.
    private int maxLevel;

    [SerializeField]
    // The default boost the server starts out with.
    private int defaultBoost;

    [SerializeField]
    // The maximum boost the server can have.
    private int maxBoost;

    [SerializeField]
    // The boosts needed for each server level. Boosts needed at level 0 means that will be the default for the server.
    private List<int> boostTable;

    [SerializeField]
    // The server icon prefab. The index correspond with the server icon at that level.
    private List<GameObject> icon;

    [SerializeField]
    // The UI theme the server uses. Theme is per server instead of location. The player should recognize what server he/she is in at a glance.
    private ThemeSO theme;

    [SerializeField]
    // A prefab of the server gameobject.
    private GameObject gameObjectPrefab;

    [SerializeField]
    // The default location for the player when he/she arrives in the server for the first time. 
    private string defaultLocation;

    [SerializeField]
    private GameObject locationListPrefab;    // location list prefab

    public string GetDisplayName()
    {
        return displayName;
    }

    public string GetServerType()
    {
        return serverType;
    }

    public string GetDescription()
    {
        return description;
    }

    public int GetDefaultLevel()
    {
        return defaultLevel;
    }

    public int GetMaxLevel()
    {
        return maxLevel;
    }

    public int GetDefaultBoost()
    {
        return defaultBoost;
    }

    public int GetMaxBoost()
    {
        return maxBoost;
    }

    public int GetBoostTable(int lvl)
    {
        return boostTable[lvl];
    }

    public GameObject GetIcon(int lvl)
    {
        return icon[lvl];
    }

    public ThemeSO GetTheme()
    {
        return theme;
    }

    public GameObject GetGameObjectPrefab()
    {
        return gameObjectPrefab;
    }

    public string GetDefaultLocation()
    {
        return defaultLocation;
    }

    // inviteLink?

    // SO of server emoji list???

    // music in location instead of server

    // role colors?
}