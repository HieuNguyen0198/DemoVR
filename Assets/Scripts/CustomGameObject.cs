using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGameObject
{
    public string name;

    public float posisionX;
    public float posisionY;
    public float posisionZ;

    public float rotationX;
    public float rotationY;
    public float rotationZ;

    public float ScaleX;
    public float ScaleY;
    public float ScaleZ;

    public CustomGameObject(string s, float x, float y, float z, float x2, float y2, float z2, float x3, float y3, float z3)
    {
        name = s;
        posisionX = x;
        posisionY = y;
        posisionZ = z;
        rotationX = x2;
        rotationY = y2;
        rotationZ = z2;
        ScaleX = x3;
        ScaleY = y3;
        ScaleZ = z3;
    }

    public CustomGameObject()
    {

    }
}
