using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    private Transform cube;
    private Transform childCube;
    private GameObject cloneChildCube;
    private GameObject gameObjectParent;
    private Transform currentObjectParent;
    public OVRInput.Button clickButton = OVRInput.Button.One;
    private RaycastHit vision;
    public float rayLength;
    public Rigidbody rd;
    private bool checkScale = false;
    public LaserPointer laserPointer;

    private float R = 0;

    // Start is called before the first frame update
    void Start()
    {
        rayLength = 30.0f;
        //Debug.Log(childCube.name);
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(clickButton))
        {
            var mask = LayerMask.GetMask("Scale");
            if (Physics.Raycast(rd.transform.position, rd.transform.forward, out vision, rayLength, mask))
            {
                if (checkScale == false)
                {
                    if (vision.collider.tag == "Scale+")
                    {
                        childCube = vision.collider.transform;
                        cube = childCube.parent.parent;

                        //set parent
                        gameObjectParent = new GameObject();
                        gameObjectParent.transform.position = new Vector3(cube.position.x, cube.position.y - 0.25f, cube.position.z);
                        currentObjectParent = cube.transform.parent;
                        cube.SetParent(gameObjectParent.transform, true);

                        cloneChildCube = Instantiate(childCube.gameObject, childCube.position, Quaternion.identity);
                        cloneChildCube.transform.SetParent(rd.transform, true);
                        cloneChildCube.SetActive(false);

                        checkScale = true;
                    }
                }
            }
        }
        if (OVRInput.GetUp(clickButton))
        {
            if(checkScale)
            {
                Destroy(cloneChildCube);
                checkScale = false;

                cube.SetParent(currentObjectParent, true);
                Destroy(gameObjectParent);

                //unhide laser
                laserPointer.laserBeamBehavior = LaserPointer.LaserBeamBehavior.On;
            }          
        }

        if (checkScale)
        {
            if (childCube.position != cloneChildCube.transform.position)
            {
                R = Mathf.Sqrt((Mathf.Pow((childCube.position.x - cloneChildCube.transform.position.x), 2)) +
                 (Mathf.Pow((childCube.position.y - cloneChildCube.transform.position.y), 2)) +
                 (Mathf.Pow((childCube.position.z - cloneChildCube.transform.position.z), 2)));

                if (Mathf.Pow(childCube.position.x - cube.transform.position.x, 2) + Mathf.Pow(childCube.position.y - cube.transform.position.y, 2) + Mathf.Pow(childCube.position.z - cube.transform.position.z, 2) >
                    Mathf.Pow(cloneChildCube.transform.position.x - cube.transform.position.x, 2) + Mathf.Pow(cloneChildCube.transform.position.y - cube.transform.position.y, 2) + Mathf.Pow(cloneChildCube.transform.position.z - cube.transform.position.z, 2))
                {
                    R *= -1;
                }

                //limit scale 0.5, 5
                Vector3 vector3 = new Vector3();
                vector3.x = gameObjectParent.transform.localScale.x + ((2 * R) / Mathf.Sqrt(2)) / gameObjectParent.transform.localScale.x;
                vector3.y = gameObjectParent.transform.localScale.y + ((2 * R) / Mathf.Sqrt(2)) / gameObjectParent.transform.localScale.y;
                vector3.z = gameObjectParent.transform.localScale.z + ((2 * R) / Mathf.Sqrt(2)) / gameObjectParent.transform.localScale.z;

                if (vector3.x >= 0.5 && vector3.y >= 0.5 && vector3.z >= 0.5
                    && vector3.x <= 3 && vector3.y <= 3 && vector3.z <= 3)
                {
                    gameObjectParent.transform.localScale = vector3;
                    cloneChildCube.transform.position = childCube.position;

                    //hide laser pointer
                    laserPointer.laserBeamBehavior = LaserPointer.LaserBeamBehavior.Off;
                }
                else if (vector3.x < 0.5 && vector3.y < 0.5 && vector3.z < 0.5)
                {
                    gameObjectParent.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    cloneChildCube.transform.position = childCube.position;

                    //hide laser pointer
                    laserPointer.laserBeamBehavior = LaserPointer.LaserBeamBehavior.Off;
                }
            }
        }
    }
}
