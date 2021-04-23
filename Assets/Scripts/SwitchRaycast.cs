using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchRaycast : MonoBehaviour
{
    public GameObject eventSystem;
    public Transform righhand;
    public Transform lefthand;


    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            eventSystem.GetComponent<OVRInputModule>().rayTransform = righhand;
        }

        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            eventSystem.GetComponent<OVRInputModule>().rayTransform = lefthand;
        }
    }
}
