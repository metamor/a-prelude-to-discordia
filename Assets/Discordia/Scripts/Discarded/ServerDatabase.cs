/*using System.Collections.Generic;

// This class creates a dictionary that maps the server name with its scriptable object data.
public class ServerDatabase
{
    // Make the ServerDatabase a singleton so it can be accessed from anywhere in the game.
    private static readonly ServerDatabase instance = new ServerDatabase();

    // The database scriptable object that holds the data of all the servers.
    private DatabaseSO database = null;

    private Dictionary<string, ServerDataSO> serverDatabase = null;

    static ServerDatabase()
    {
    }

    private ServerDatabase()
    {
    }

    public static ServerDatabase Instance
    {
        get
        {
            return instance;
        }
    }

    public void SetDatabase(DatabaseSO db)
    {
        database = db;
    }

    // Get all server data from the database scriptable object and put them in a dictionary with the key being the server id and the value being the server data scriptable object.
    public void Init()
    {
        if (database != null)
        {
            int databaseSize = database.Count();

            serverDatabase = new Dictionary<string, ServerDataSO>(databaseSize);

            // Builds the database of servers which is just a dictionary.
            for (int i = 0; i < databaseSize; i++)
            {
                ServerDataSO server = (ServerDataSO)database.GetValue(i);

                if (server != null)
                {
                    serverDatabase[server.GetId()] = server;
                }
            }
        }
    }

    // Get the number of servers in the database.
    public int Count()
    {
        return serverDatabase.Count;
    }

    public ServerDataSO Get(string serverID)
    {
        if (serverDatabase.TryGetValue(serverID, out ServerDataSO server))
        {
            return server;
        }
        else
        {
            return null;
        }
    }
}*/
