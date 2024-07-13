using UnityEngine;

// All scriptable objects extends from this class inorder to give all scriptable objects the id field.
public class DataSO : ScriptableObject
{
    [SerializeField]
    // The ID of the scriptable object type must be unique.
    protected string id = "";

    public string GetId()
    {
        return id;
    }
}
