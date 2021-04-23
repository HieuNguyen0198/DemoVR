using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjectUI : MonoBehaviour
{
    public Rigidbody rbHand;
    private GameObject newObject;
    private RaycastHit vision;
    public float rayLenght;
    public OVRInput.Button clickButton = OVRInput.Button.One;

    // Start is called before the first frame update
    void Start()
    {
        rayLenght = 30.0f;
        //transformThisOject = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var mask = LayerMask.GetMask("UIS");
            if (Physics.Raycast(rbHand.transform.position, rbHand.transform.forward, out vision, rayLenght, mask))
            {   
                if (vision.collider.tag == "ItemSelect")
                {
                    string name = vision.collider.gameObject.name;
                    newObject = GameObject.Find(name);
                    Spawner spawner = new Spawner();
                    spawner = newObject.GetComponent<Spawner>();
                    spawner.Spawn(rbHand.transform);

                    //save object to list
                    GameObject g = new GameObject();
                    g = spawner.getGameObject();
                    GlobalVariable.add(g);

                 
                    Debug.Log(GlobalVariable.getStringAll());
                }
            }
        }

        if (OVRInput.GetDown(clickButton))
        {
            var mask = LayerMask.GetMask("UIS");
            if (Physics.Raycast(rbHand.transform.position, rbHand.transform.forward, out vision, rayLenght, mask))
            {
                if (vision.collider.tag == "ItemSelect")
                {
                    string name = vision.collider.gameObject.name;
                    newObject = GameObject.Find(name);

                    //Spawn
                    Spawner spawner = new Spawner();
                    spawner = newObject.GetComponent<Spawner>();
                    spawner.Spawn(rbHand.transform);

                    //save object to list
                    GameObject g = new GameObject();
                    g = spawner.getGameObject();
                    GlobalVariable.add(g);


                    Debug.Log(GlobalVariable.getStringAll());
                }
            }
        }
    }
}
