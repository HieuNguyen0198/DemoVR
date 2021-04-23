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
    Transform currentObjectParentRaycasted;
    bool isDragging = false;

    //Vector3 handPosition;
    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(clickButton))
        {
            var mask = LayerMask.GetMask("Button");
            if (Physics.Raycast(rd.transform.position, rd.transform.forward, out vision, rayLength, mask))
            {
                if (vision.collider.tag == "Cube")
                {
                    currentObjectRaycasted = vision.collider.transform;
                    currentObjectParentRaycasted = currentObjectRaycasted.parent;
                    currentObjectRaycasted.SetParent(hands, true);
                    currentObjectRaycasted.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    isDragging = true;
                }
                else
                {
                    currentObjectRaycasted = null;
                }
            }
        }

        if (isDragging == false)
        {

        }

        if (OVRInput.GetUp(clickButton))
        {
            if(isDragging)
            {
                currentObjectRaycasted.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                currentObjectRaycasted.SetParent(currentObjectParentRaycasted, true);
                Destroy(currentObjectParentRaycasted);
                Destroy(currentObjectRaycasted);
                isDragging = false;
            }
        }
    }
}
