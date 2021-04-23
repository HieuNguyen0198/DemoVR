using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseMaterial : MonoBehaviour
{
    private RaycastHit vision;
    public Rigidbody rbHand;
    public float rayLeght;
    public OVRInput.Button clickButton = OVRInput.Button.One;
    public GameObject chooseMaterial;
    private GameObject ob = null;

    private GameObject childObject;

    // Start is called before the first frame update
    void Start()
    {
        rayLeght = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(clickButton))
        {
            var mask = LayerMask.GetMask("Button");
            if(Physics.Raycast(rbHand.transform.position, rbHand.transform.forward, out vision, rayLeght, mask))
            {
                if(vision.collider.tag == "Cube")
                {
                    if(ob != null)
                    {
                        if(vision.collider.gameObject != ob)
                        {
                            childObject.SetActive(false);
                        }
                    }
                    chooseMaterial.SetActive(true);
                    ob = vision.collider.gameObject;
                    childObject = ob.transform.GetChild(3).gameObject;
                    childObject.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            var mask = LayerMask.GetMask("Button");
            if (Physics.Raycast(rbHand.transform.position, rbHand.transform.forward, out vision, rayLeght, mask))
            {
                if (ob != null)
                {
                    if (vision.collider.gameObject != ob)
                    {
                        childObject.SetActive(false);
                    }
                }
                chooseMaterial.SetActive(true);
                ob = vision.collider.gameObject;
                childObject = ob.transform.GetChild(3).gameObject;
                childObject.SetActive(true);
            }
        }
        //
    }
    public void OnClickChoose(GameObject btn)
    {
        Image imageButton = btn.GetComponent<Image>();
        MeshRenderer meshRenderer = ob.GetComponent<MeshRenderer>();
        //change

        meshRenderer.material = imageButton.material;
    }

    public void onClickBack()
    {
        chooseMaterial.SetActive(false);
        childObject.SetActive(false);
    }


    //xoa object
    public void onClickDelete()
    {
        /*for (int i = 0; i < GlobalVariable.list.Count; i ++)
        {
            if(GlobalVariable.list[i] == ob)
            {
                GlobalVariable.list.RemoveAt(i);
            }
        }*/

        Debug.Log("---> D" + ob);
        Destroy(ob);
        EventSystem.current.SetSelectedGameObject(null);

    }
}
