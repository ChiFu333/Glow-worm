using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InteractionComponent : MonoBehaviour
{
    public UnityEvent DoByClick;
    [SerializeField] private GameObject EIcon;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && EIcon.activeInHierarchy) DoByClick.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player")) EIcon.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player")) EIcon.SetActive(false);
    }
}
