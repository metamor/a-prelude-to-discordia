using Unity.Cinemachine;
using UnityEngine;

public class ManualUpdateCM : MonoBehaviour
{
    CinemachineBrain brain;

    void Start()
    {
        brain = GetComponent<CinemachineBrain>();
        //brain.m_UpdateMethod = CinemachineBrain.UpdateMethod.ManualUpdate;
    }

    void Update()
    {
        brain.ManualUpdate();
    }
}