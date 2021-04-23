using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject UIMenu;
    public GameObject UICreate;
    public GameObject UIRoom;

    private void Start()
    {
        UIMenu.SetActive(true);
        UICreate.SetActive(false);
        UIRoom.SetActive(false);
    }

    //Menu 
    public void OnClickCreateButton()
    {
        UIMenu.SetActive(false);
        UICreate.SetActive(true);
    }

    public void OnClickLoadRoomButton()
    {
        UIMenu.SetActive(false);
        UIRoom.SetActive(true);
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    //Create
    public void OnclickRoom1()
    {
        SceneManager.LoadScene("Room1");
        GlobalStringName.slot = "";
    }

    public void OnClickRoom2()
    {
        SceneManager.LoadScene("Room2");
        GlobalStringName.slot = "";
    }

    public void OnClickRoom3()
    {
        SceneManager.LoadScene("Room3");
        GlobalStringName.slot = "";
    }

    //Load
    public void OnclickSlot1()
    {
        string str = PlayerPrefs.GetString("name1");
        if(str != "")
        {
            GlobalStringName.slot = "slot1";
            SceneManager.LoadScene(str);
        }      
    }

    public void OnclickSlot2()
    {
        string str = PlayerPrefs.GetString("name2");
        if(str != "")
        {
            GlobalStringName.slot = "slot2";
            SceneManager.LoadScene(str);
        }
    }

    public void OnclickSlot3()
    {
        string str = PlayerPrefs.GetString("name3");
        if(str != "")
        {
            GlobalStringName.slot = "slot3";
            SceneManager.LoadScene(str);
        }
    }

    public void OnclickSlot4()
    {
        string str = PlayerPrefs.GetString("name4");
        if(str != "")
        {
            GlobalStringName.slot = "slot4";
            SceneManager.LoadScene(str);
        }
    }

    public void OnclickSlot5()
    {
        string str = PlayerPrefs.GetString("name5");
        if(str != "")
        {
            GlobalStringName.slot = "slot5";
            SceneManager.LoadScene(str);
        }
    }

    public void OnclickSlot6()
    {
        string str = PlayerPrefs.GetString("name6");
        if(str != "")
        {
            GlobalStringName.slot = "slot6";
            SceneManager.LoadScene(str);
        }
    }

    public void OnclickBack()
    {
        UIRoom.SetActive(false);
        UICreate.SetActive(false);
        UIMenu.SetActive(true);
    }
}
