using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class RaycastCube : MonoBehaviour
{
    private RaycastHit vision;
    public float rayLength;
    //private bool isGrabbed;
    public Rigidbody rd;

    public Transform hands;
    //private Rigidbody grabbedObject;

    public OVRInput.Button clickButton = OVRInput.Button.SecondaryHandTrigger;
    //public OVRInput.Controller controller = OVRInput.Controller.All;

    // Start is called before the first frame update
    void Start()
    {
        rayLength = 30.0f;
        //isGrabbed = false;
        rd = GetComponent<Rigidbody>();
    }
    
    Transform currentObjectRaycasted;
    Rigidbody cubeRb;
    Transform currentObjectParentRaycasted;
    //bool isDragging = false;

    //Vector3 handPosition;
    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(clickButton))
        {
            if (Physics.Raycast(rd.transform.position, rd.transform.forward, out vision, rayLength))
            {
                if (vision.collider.tag == "Cube")
                {
                    currentObjectRaycasted = vision.collider.transform;
                    cubeRb = vision.rigidbody;
                    currentObjectParentRaycasted = currentObjectRaycasted.parent;
                    //Debug.Log(vision.collider.name + "abc");
                    currentObjectRaycasted.SetParent(hands, true);
                    cubeRb.isKinematic = true;
                }
                else
                {
                    currentObjectRaycasted = null;
                }
            }
        }
        if(currentObjectRaycasted != null)
        {

        }
        if (OVRInput.GetUp(clickButton))
        {
            if(currentObjectRaycasted != null)
            {
                cubeRb.isKinematic = false;
                currentObjectRaycasted.SetParent(currentObjectParentRaycasted, true);
                currentObjectRaycasted = null;
                currentObjectParentRaycasted = null;
                cubeRb = null;
            }
        }
    }
}
