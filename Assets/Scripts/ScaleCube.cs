using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCube : MonoBehaviour
{
    private RaycastHit vision;
    public OVRInput.Button clickButton = OVRInput.Button.One;
    private Transform currentObjectRaycasted;
    public Rigidbody rb;
    public float rayLength;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rayLength = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(clickButton))
        {
            if(Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLength))
            {
                //Scale
                string i = vision.collider.tag;
                switch(i)
                {
                    case "ScaleY+":
                        currentObjectRaycasted = vision.collider.transform.parent.parent;
                        currentObjectRaycasted.localScale += new Vector3(0, 0.1f, 0);
                        break;
                    case "ScaleY-":
                        currentObjectRaycasted = vision.collider.transform.parent.parent;
                        currentObjectRaycasted.localScale += new Vector3(0, -0.1f, 0);
                        break;
                    case "ScaleX+":
                        currentObjectRaycasted = vision.collider.transform.parent.parent;
                        currentObjectRaycasted.localScale += new Vector3(0.1f, 0, 0);
                        break;
                    case "ScaleX-":
                        currentObjectRaycasted = vision.collider.transform.parent.parent;
                        currentObjectRaycasted.localScale += new Vector3(-0.1f, 0, 0);
                        break;
                    case "ScaleZ+":
                        currentObjectRaycasted = vision.collider.transform.parent.parent;
                        currentObjectRaycasted.localScale += new Vector3(0, 0, 0.1f);
                        break;
                    case "ScaleZ-":
                        currentObjectRaycasted = vision.collider.transform.parent.parent;
                        currentObjectRaycasted.localScale += new Vector3(0, 0, -0.1f);
                        break;
                    case "RotationX":
                        currentObjectRaycasted = vision.collider.transform.parent.parent;
                        currentObjectRaycasted.Rotate(90f, 0, 0);
                        break; 
                    case "RotationY":
                        currentObjectRaycasted = vision.collider.transform.parent.parent;
                        currentObjectRaycasted.Rotate(0, 15f, 0);
                        break;
                    case "RotationZ":
                        currentObjectRaycasted = vision.collider.transform.parent.parent;
                        currentObjectRaycasted.Rotate(0, 0, 90f);
                        break;
                }

                /*if (vision.collider.tag == "ScaleY+")
                {
                    currentObjectRaycasted = vision.collider.transform.parent.parent;
                    currentObjectRaycasted.localScale += new Vector3(0, 0.1f, 0);
                }
                else if (vision.collider.tag == "ScaleY-")
                {
                    currentObjectRaycasted = vision.collider.transform.parent.parent;
                    currentObjectRaycasted.localScale += new Vector3(0, -0.1f, 0);
                }
                else if (vision.collider.tag == "ScaleX+")
                {
                    currentObjectRaycasted = vision.collider.transform.parent.parent;
                    currentObjectRaycasted.localScale += new Vector3(0.1f, 0, 0);
                }
                else if (vision.collider.tag == "ScaleX-")
                {
                    currentObjectRaycasted = vision.collider.transform.parent.parent;
                    currentObjectRaycasted.localScale += new Vector3(-0.1f, 0, 0);
                }
                else if (vision.collider.tag == "ScaleZ+")
                {
                    currentObjectRaycasted = vision.collider.transform.parent.parent;
                    currentObjectRaycasted.localScale += new Vector3(0, 0, 0.1f);
                }
                else if (vision.collider.tag == "ScaleZ-")
                {
                    currentObjectRaycasted = vision.collider.transform.parent.parent;
                    currentObjectRaycasted.localScale += new Vector3(0, 0, -0.1f);
                }
                else if (vision.collider.tag == "Scale+")
                {
                    currentObjectRaycasted = vision.collider.transform.parent.parent;
                    currentObjectRaycasted.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                }
                else if (vision.collider.tag == "ScaleZ-")
                {
                    currentObjectRaycasted = vision.collider.transform.parent.parent;
                    currentObjectRaycasted.localScale += new Vector3(-0.1f, -0.1f, -0.1f);
                }
                //Rotation
                else if (vision.collider.tag == "RotationX")
                {
                    currentObjectRaycasted = vision.collider.transform.parent.parent;
                    currentObjectRaycasted.Rotate(90f, 0, 0);
                }
                else if (vision.collider.tag == "RotationY")
                {
                    currentObjectRaycasted = vision.collider.transform.parent.parent;
                    currentObjectRaycasted.Rotate(0, 15f, 0);
                }
                else if (vision.collider.tag == "RotationZ")
                {
                    currentObjectRaycasted = vision.collider.transform.parent.parent;
                    currentObjectRaycasted.Rotate(0, 0, 90f);
                }*/
            }
        }
    }
}
