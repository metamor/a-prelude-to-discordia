using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server
{
    [SerializeField]
    private ServerDataSO data;

    // might need a string for the id to serialize in json?

    [SerializeField]
    // The current level of the server.
    private int level;

    [SerializeField]
    // The amount of boosts the server has.
    private int boosts;

    // locked
    // current location

    // a list of locations that are unlocked? not all locations need to be unlocked/discovered?

    // default constructor that's called if no data on this server is found in the save file
    public Server(ServerDataSO serverData)
    {
        data = serverData;
    }

    public string GetID()
    {
        return data.GetId();
    }

    public string GetDisplayName()
    {
        return data.GetDisplayName();
    }

    // server type

    private void LevelUp()
    {
        // check amount of boost
    }

    public bool Boost(int amount)
    {
        // check if the boost amount will pass the max boost
        // if will pass the max, return false since too much boost
        // if true, set boost and see if level up
        return false;
    }


    // public increaseBoost then check if not at max then calculate if the server will level up?

    // public delevelServer 

    // boost is need to increase and decrease server?

    // in player server list c# class
    // resetLocation() which set current location back to the original; used for new game; for each server in dictionary set location
    //  also in server list class, if server not found from the string key, create a new Server object and fill it up?
    //  this way if we add new servers in the game, don't have to make the entire list, just add the server since it's not found


}
