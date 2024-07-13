using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// think of serverlist as a equip list; a character has a list of equipped items but doesn't have access to the entire item database
// the player 'equipped' servers

public class ServerList : MonoBehaviour
{
    public List<GameObject> servers;

    // on start up or when called, create all the server prefab gameobjects and fill them in the list
    // the server prefab may have a number field to display notification number on its icon and maybe keep track of boosted level to display different avatar per level?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
