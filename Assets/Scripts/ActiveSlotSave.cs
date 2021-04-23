using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSlotSave : MonoBehaviour
{
    public GameObject UIChooseSlot;
    public List<GameObject> buttons = new List<GameObject>();
    List<string> strs = new List<string>();
    public Color _color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (UIChooseSlot.activeSelf)
        {
            for (int i = 0; i < 6; i++)
            {
                strs.Add(PlayerPrefs.GetString("name" + (i + 1).ToString()));
                Debug.Log(strs[i]);
            }
        }

        if (UIChooseSlot.activeSelf)
        {
            //check slot have data?
            for(int i = 0;i < 6 ;i++)
            {
                if(strs[i] != "")
                {
                    buttons[i].transform.GetChild(0).GetComponent<Text>().text = strs[i];
                    buttons[i].GetComponent<Image>().color = _color;
                }
            }

        }
    }
}
