using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariable
{
    public static List<GameObject> list = new List<GameObject>();
    public static void add(GameObject game)
    {
        list.Add(game);
    }

    public static GameObject get(int index)
    {
        GameObject gameObject = new GameObject();
        gameObject = list[index];
        return gameObject;
    }

    public static string getStringAll()
    {
        string str = "";
        for(int i = 0; i < list.Count;i++)
        {
            str += list[i].name + "=";
        }
        return str;
    }

    public static string getStringToSave()
    {
        string str = "";
        for(int i = 0; i < list.Count; i++)
        {
            str += "=" + list[i].name
               + ":" + list[i].transform.position.x
               + ":" + list[i].transform.position.y
               + ":" + list[i].transform.position.z
               + ":" + list[i].transform.rotation.x
               + ":" + list[i].transform.rotation.y
               + ":" + list[i].transform.rotation.z
               + ":" + list[i].transform.localScale.x
               + ":" + list[i].transform.localScale.y
               + ":" + list[i].transform.localScale.z;

            string str2 = list[i].GetComponent<MeshRenderer>().material.name;
            string[] str3 = str2.Split(' ');

            str += ":" + str3[0];
        }
        return str;
    }

    public static void SavePlayerprefs()
    {
        PlayerPrefs.SetString("save", GlobalVariable.getStringToSave());
    }
}
