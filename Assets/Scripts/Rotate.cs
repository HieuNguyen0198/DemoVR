using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private RaycastHit vision;
    public float rayLenght;
    public Rigidbody rb;
    private Transform childCube;
    private Transform cube;
    private GameObject cloneChildCube;
    private GameObject currentCloneChildCube;
    public OVRInput.Button clickButton = OVRInput.Button.One;
    private bool checkRotate = false;
    private float R = 0;
    public LaserPointer laserPointer;

    // Start is called before the first frame update
    void Start()
    {
        rayLenght = 30f;
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(clickButton))
        {
            var mask = LayerMask.GetMask("Scale");
            if (Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLenght, mask))
            {
                if (!checkRotate)
                {
                    if (vision.collider.tag == "Rotation")
                    {
                        childCube = vision.collider.transform;
                        cube = childCube.parent.parent;

                        //clone child cube
                        cloneChildCube = Instantiate(childCube.gameObject, childCube.position, Quaternion.identity);
                        cloneChildCube.transform.SetParent(rb.transform, true);
                        cloneChildCube.SetActive(false);

                        currentCloneChildCube = Instantiate(cloneChildCube, childCube.position, Quaternion.identity);

                        checkRotate = true;
                    }
                }
            }
        }
        if(OVRInput.GetUp(clickButton))
        {
            if(checkRotate)
            {
                checkRotate = false;
                //unhide laser
                laserPointer.laserBeamBehavior = LaserPointer.LaserBeamBehavior.On;
            }  
        }
        if(checkRotate)
        {
            Debug.Log(childCube.position);
            Debug.Log(cloneChildCube.transform.position);
            if (currentCloneChildCube.transform.position != cloneChildCube.transform.position)
            {
                R = Mathf.Sqrt((Mathf.Pow((currentCloneChildCube.transform.position.x - cloneChildCube.transform.position.x), 2)) +
                 (Mathf.Pow((currentCloneChildCube.transform.position.z - cloneChildCube.transform.position.z), 2)));

                if(isRight(rb.transform.position, cloneChildCube.transform.position, currentCloneChildCube.transform.position))
                {
                    R *= -1;
                }

                Debug.Log(R);

                Vector3 vector3 = new Vector3();
                vector3.x = cube.localRotation.x;
                vector3.y = cube.localRotation.y + R*30;
                vector3.z = cube.localRotation.z;

                Debug.Log(vector3);

                cube.Rotate(vector3);

                //hide laser pointer
                laserPointer.laserBeamBehavior = LaserPointer.LaserBeamBehavior.Off;

                currentCloneChildCube.transform.position = cloneChildCube.transform.position;
            }
        }


        /*
        if (Input.GetKeyDown(KeyCode.Y))
        {
            var mask = LayerMask.GetMask("Scale");
            if (Physics.Raycast(rb.transform.position, rb.transform.forward, out vision, rayLenght, mask))
            {
                if (!checkRotate)
                {
                    if (vision.collider.tag == "Rotation")
                    {
                        childCube = vision.collider.transform;
                        cube = childCube.parent.parent;

                        //clone child cube
                        cloneChildCube = Instantiate(childCube.gameObject, childCube.position, Quaternion.identity);
                        cloneChildCube.transform.SetParent(rb.transform, true);
                        cloneChildCube.SetActive(false);

                        currentCloneChildCube = Instantiate(cloneChildCube, childCube.position, Quaternion.identity);

                        Debug.Log(childCube.position);
                        Debug.Log(cloneChildCube.transform.position);

                        checkRotate = true;
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            checkRotate = false;

            //unhide laser
            laserPointer.laserBeamBehavior = LaserPointer.LaserBeamBehavior.On;
        }
        if (checkRotate)
        {
            Debug.Log(childCube.position);
            Debug.Log(cloneChildCube.transform.position);
            if (currentCloneChildCube.transform.position != cloneChildCube.transform.position)
            {
                R = Mathf.Sqrt((Mathf.Pow((currentCloneChildCube.transform.position.x - cloneChildCube.transform.position.x), 2)) +
                 (Mathf.Pow((currentCloneChildCube.transform.position.z - cloneChildCube.transform.position.z), 2)));

                if(isRight(rb.transform.position, cloneChildCube.transform.position, currentCloneChildCube.transform.position))
                {
                    R *= -1;
                }

                Debug.Log(R);

                Vector3 vector3 = new Vector3();
                vector3.x = cube.localRotation.x;
                vector3.y = cube.localRotation.y + R*30;
                vector3.z = cube.localRotation.z;

                Debug.Log(vector3);

                cube.Rotate(vector3);

                //hide laser pointer
                laserPointer.laserBeamBehavior = LaserPointer.LaserBeamBehavior.Off;

                currentCloneChildCube.transform.position = cloneChildCube.transform.position;
            }
        }
        */
    }


    //false = c left, true = c right
    //a = hand, b = raycasthit, c = point.
    private bool isRight(Vector3 a, Vector3 b, Vector3 c)
    {
        return ((b.x - a.x) * (c.y - a.y) - (b.y - a.y) * (c.x - a.x)) < 0;
    }
}
