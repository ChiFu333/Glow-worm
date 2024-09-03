using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonLogic : MonoBehaviour
{
    public bool isReady = false;
    public Sprite on,off;

    public void Pressed()
    {
        if(isReady)
        {
            isReady = false;
            GetComponent<Image>().sprite = off;
        }
        else
        {
            isReady = true;
            GetComponent<Image>().sprite = on;
        }
    }
}
