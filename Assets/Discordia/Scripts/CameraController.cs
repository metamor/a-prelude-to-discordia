using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public GameObject cameraUIRig = null;

    // public int (original camera origin); this will change to different coords depending on the player resolution? like 16:10 or 4:3?
    
    public GameObject GetCameraUIRig()
    {
        return cameraUIRig;
    }
}
