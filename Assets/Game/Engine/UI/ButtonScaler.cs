using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScaler : MonoBehaviour
{
    [SerializeField] float scaleRatio = 0.7f;
    public void Start()
    {
        Register();
    }
    public void Register() 
    {
        EventTrigger eventTrigger = GetComponent<EventTrigger>();
        if (eventTrigger == null) eventTrigger = gameObject.AddComponent<EventTrigger>();
        
        // Pointer Enter
        EventTrigger.Entry enterUIEntry = new EventTrigger.Entry();
        enterUIEntry.eventID = EventTriggerType.PointerEnter;
        enterUIEntry.callback.AddListener(OnEnteredUI);
        eventTrigger.triggers.Add(enterUIEntry);
        // Pointer Exit
        enterUIEntry = new EventTrigger.Entry();
        enterUIEntry.eventID = EventTriggerType.PointerExit;
        enterUIEntry.callback.AddListener(OnExitUI);
        eventTrigger.triggers.Add(enterUIEntry);
    }
    public void OnEnteredUI(BaseEventData eventData)
    { 
        transform.GetChild(0).GetComponent<RectTransform>().localScale = Vector3.one * scaleRatio;

    }
    public void OnExitUI(BaseEventData eventData)
    { 
        transform.GetChild(0).GetComponent<RectTransform>().localScale = Vector3.one;
    }
}
