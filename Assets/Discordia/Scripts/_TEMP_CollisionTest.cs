using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Hit 2D!");
    }

    void OnTriggerStay(Collider coll)
    {
        Debug.Log("Hit 3D!");
    }
}
