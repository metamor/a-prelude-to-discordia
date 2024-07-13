using System.Collections.Generic;
using UnityEngine;

// A scriptable object that acts as a database that holds a list of scriptable objects to have easy reference to them.
[CreateAssetMenu(fileName = "NewDatabase", menuName = "Scriptable Object/Database")]
public class DatabaseSO : ScriptableObject
{
    [SerializeField]
    private List<DataSO> data;

    private Dictionary<string, DataSO> database = new Dictionary<string, DataSO>();

    public void CreateDatabase()
    {
        int totalData = data.Count;

        for (int i = 0; i < totalData; i++)
        {
            database.Add(data[i].GetId(), data[i]);

            /*if (database.TryAdd(data[i].GetId(), data[i]) == false)
            {
                continue;
            }*/
        }
    }

    // Get the number of entries in the database.
    public int Count()
    {
        return database.Count;
    }

    // Gets the value from the database that is associated with the key.
    public DataSO GetData(string key)
    {
        return database[key];

        /*if (database.TryGetValue(key, out DataSO value))
        {
            return value;
        }
        else
        {
            return null;
        }*/
    }

    public bool ContainsData(string key)
    {
        return database.ContainsKey(key);
    }

}
