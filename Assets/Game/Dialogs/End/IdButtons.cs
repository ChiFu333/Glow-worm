using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IdButtons : MonoBehaviour
{
    public int id;
    [HideInInspector] public TMP_Text text;
    public void UpdateUI(string t)
    {
        text = GetComponentInChildren<TMP_Text>();
        text.text = t;
    }
}
