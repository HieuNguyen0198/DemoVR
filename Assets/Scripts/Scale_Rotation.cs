using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_Rotation : MonoBehaviour
{
    private RaycastHit vision;
    public OVRInput.Button clickButton = OVRInput.Button.One;
    private Transform currentObjectRaycasted;
    public Rigidbody rb;
    public float rayLength;

    public void ScaleX()
    {
        if (OVRInput.GetDown(clickButton))
        {
            if (Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLength))
            {
                currentObjectRaycasted = vision.collider.transform.parent.parent;
                currentObjectRaycasted.localScale += new Vector3(0.1f, 0, 0);
            }
        }
    }

    public void ScaleX_()
    {
        if (OVRInput.GetDown(clickButton))
        {
            if (Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLength))
            {
                currentObjectRaycasted = vision.collider.transform.parent.parent;
                currentObjectRaycasted.localScale += new Vector3(-0.1f, 0, 0);
            }
        }
    }

    public void ScaleY()
    {
        if (OVRInput.GetDown(clickButton))
        {
            if (Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLength))
            {
                currentObjectRaycasted = vision.collider.transform.parent.parent;
                currentObjectRaycasted.localScale += new Vector3(0, 0.1f, 0);
            }
        }
    }

    public void ScaleY_()
    {
        if (OVRInput.GetDown(clickButton))
        {
            if (Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLength))
            {
                currentObjectRaycasted = vision.collider.transform.parent.parent;
                currentObjectRaycasted.localScale += new Vector3(0, -0.1f, 0);
            }
        }
    }

    public void ScaleZ()
    {
        if (OVRInput.GetDown(clickButton))
        {
            if (Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLength))
            {
                currentObjectRaycasted = vision.collider.transform.parent.parent;
                currentObjectRaycasted.localScale += new Vector3(0, 0, 0.1f);
            }
        }
    }

    public void ScaleZ_()
    {
        if (OVRInput.GetDown(clickButton))
        {
            if (Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLength))
            {
                currentObjectRaycasted = vision.collider.transform.parent.parent;
                currentObjectRaycasted.localScale += new Vector3(0, 0, -0.1f);
            }
        }
    }

    public void RotationX()
    {
        if (OVRInput.GetDown(clickButton))
        {
            if (Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLength))
            {
                currentObjectRaycasted = vision.collider.transform.parent.parent;
                currentObjectRaycasted.Rotate(90f, 0, 0);
            }
        }
    }

    public void RotationY()
    {
        if (OVRInput.GetDown(clickButton))
        {
            if (Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLength))
            {
                currentObjectRaycasted = vision.collider.transform.parent.parent;
                currentObjectRaycasted.Rotate(0, 15f, 0);
            }
        }
    }

    public void RotationZ()
    {
        if (OVRInput.GetDown(clickButton))
        {
            if (Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLength))
            {
                currentObjectRaycasted = vision.collider.transform.parent.parent;
                currentObjectRaycasted.Rotate(0, 0, 90f);
            }
        }
    }
}
