using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(GlobalVariable.getStringToSave());
            PlayerPrefs.SetString("slot", GlobalVariable.getStringToSave());
        }
    }

    //save with UI
    public void onClickSaveButton1(Text btnText)
    {
        //string name Actice scene
        string name = SceneManager.GetActiveScene().name;

        //string save object
        PlayerPrefs.SetString("name1", name);
        PlayerPrefs.SetString("slot1", GlobalVariable.getStringToSave());

        text.text = "1.Room:" + name;
        btnText.text = name;
    }

    public void onClickSaveButton2(Text btnText)
    {
        //string name Actice scene
        string name = SceneManager.GetActiveScene().name;

        //string save object
        PlayerPrefs.SetString("name2", name);
        PlayerPrefs.SetString("slot2", GlobalVariable.getStringToSave());

        text.text = "2.Room:" + name;
        btnText.text = name;
    }

    public void onClickSaveButton3(Text btnText)
    {
        //string name Actice scene
        string name = SceneManager.GetActiveScene().name;

        //string save object
        PlayerPrefs.SetString("name3", name);
        PlayerPrefs.SetString("slot3", GlobalVariable.getStringToSave());

        text.text = "3.Room:" + name;
        btnText.text = name;
    }

    public void onClickSaveButton4(Text btnText)
    {
        //string name Actice scene
        string name = SceneManager.GetActiveScene().name;

        //string save object
        PlayerPrefs.SetString("name4", name);
        PlayerPrefs.SetString("slot4", GlobalVariable.getStringToSave());

        text.text = "4.Room:" + name;
        btnText.text = name;
    }

    public void onClickSaveButton5(Text btnText)
    {
        //string name Actice scene
        string name = SceneManager.GetActiveScene().name;

        //string save object
        PlayerPrefs.SetString("name5", name);
        PlayerPrefs.SetString("slot5", GlobalVariable.getStringToSave());

        text.text = "5.Room:" + name;
        btnText.text = name;
    }

    public void onClickSaveButton6(Text btnText)
    {
        //string name Actice scene
        string name = SceneManager.GetActiveScene().name;

        //string save object
        PlayerPrefs.SetString("name6", name);
        PlayerPrefs.SetString("slot6", GlobalVariable.getStringToSave());

        text.text = "6.Room:" + name;
        btnText.text = name;
    }
}
