using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject GameObject;
    private GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(Transform rb)
    {
        clone = Instantiate(GameObject, new Vector3(rb.transform.position.x, rb.transform.position.y + 0.3f, rb.transform.position.z + 2f), Quaternion.identity);
        clone.name = GameObject.name;
    }

    public string getInstanceID()
    {
        return clone.GetInstanceID().ToString();
    }

    public GameObject getGameObject()
    {
        return clone;
    }
}
