using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlUIPause : MonoBehaviour
{
    public GameObject UIpause;
    public GameObject UISave;
    public GameObject UIItem;
    public GameObject UImaterial;
    public OVRInput.Button button = OVRInput.Button.Two;
    public OVRInput.Button button2 = OVRInput.Button.Four;
    private bool check = true;

    // Start is called before the first frame update
    void Start()
    {
        UIpause.SetActive(false);
        UISave.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(button))
        {
            if (UIpause.active)
            {
                UIpause.SetActive(false);
                if(check)
                {
                    UIItem.SetActive(true);
                }
            }
            else
            {
                UIpause.SetActive(true);
                UIItem.SetActive(false);
            }
        }

        if(OVRInput.GetDown(button2))
        {
            if(UIItem.active)
            {
                UIItem.SetActive(false);
                check = false;
            }
            else
            {
                if(!UIpause.active)
                {
                    UIItem.SetActive(true);
                    check = true;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            if (UIpause.active)
            {
                UIpause.SetActive(false);
                if (check)
                {
                    UIItem.SetActive(true);
                }
            }
            else
            {
                UIpause.SetActive(true);
                UIItem.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if (UIItem.active)
            {
                UIItem.SetActive(false);
                check = false;
            }
            else
            {
                if (!UIpause.active)
                {
                    UIItem.SetActive(true);
                    check = true;
                }
            }
        }

        if (UIpause.active)
        {
            UImaterial.SetActive(false);
            //UIItem.SetActive(false);
        }       
    }

    public void buttonClickSave()
    {
        UIpause.SetActive(false);
        UISave.SetActive(true);
    }

    public void buttonClickResume()
    {
        UIpause.SetActive(false);
        UIItem.SetActive(true);
    }

    public void buttonClickQuit()
    {
        GlobalStringName.slot = "";
        GlobalVariable.list.Clear();
        SceneManager.LoadScene("Level0");   
    }

    public void buttonClickBack()
    {
        UISave.SetActive(false);
        UIpause.SetActive(true);
    }
}
