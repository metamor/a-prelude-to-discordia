using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// like an inventory manager, keeps track of the player's open servers
// make this a prefab so it can be instantiated at any time; not just stuck on a shared data scene?

[DisallowMultipleComponent]
public class ServerManager : MonoBehaviour
{
    //[SerializeField]
    private DatabaseSO serverDatabase;  // we'll cast the entries in this server as ServerDataSO.

    //public int serverListMaxSize = 100;

    [SerializeField]
    private List<string> activeServers;  // ServerSO basically like a server class. has all the information we need

    [SerializeField]
    // stats on all the servers the player has been to
    private Dictionary<string, Server> playerServerList;

    // list of locked or not locked servers?
    // dictionary of server name string and their int boost level?
    // server object that has level, number of boost, locked?

    // list of password and what server is will go to?


    public ServerDataSO GetServerData(string id)
    {
        return (ServerDataSO)serverDatabase.GetData(id);
    }

    // Awake is called only once and whether the script is enabled or not.
    void Awake()
    {
        activeServers = new List<string>(200);

        // Set the maximum number of servers to keep track of.
        //servers.Capacity = serverListMaxSize;

        //GameManager.Instance.SetServerManager(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void reset() which resent the capactiy, clear the list, etc back to default

    // also keep track of completed servers, visited servers, if the player can go to the server or not


    // on destroy, set game manager instance to null
}

// server's don't control their own 'quest' number popup. a quest-like system does it and put that number on the server avatar in the serverlist.
// this way we can serialize all of these quests in a file as they won't be stored with each server gameobject
// OR the server gameobjects will call the quest-like system to add a quest.

// the server gameobject might have a list of quests in can send to the quest-like system?

// servers are like npcs but instead of an enemy, it represents the server?