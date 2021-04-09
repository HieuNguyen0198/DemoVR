using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Click : MonoBehaviour
{ 
    public TextMeshProUGUI text;

    public void OnButtonClicked()
    {
        text.text = "Button 1 is clicked";
    }

    public void OnButton2Clicked()
    {
        text.text = "Button 2 is clicked";
    }

    public void OnButton3Clicked()
    {
        text.text = "Button 3 is clicked";
    }
}
