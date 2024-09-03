using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneOrganizer : MonoBehaviour {
    [Header("Holders")]
    [SerializeField] private Transform managerHolder;
    [SerializeField] private Transform uiHolder;
    [Header("Dialogue")]
    [SerializeField] private float symbolDelay = 0.02f;
    [SerializeField] private Canvas inventoryCanvasPrefab;
    [SerializeField] private Canvas dialogueCanvasPrefab;
    [SerializeField] private GameObject textPanelPrefab;
    [SerializeField] private GameObject imageBoxPrefab;
    [Header("SceneTransition")]
    [SerializeField] private GameObject transitionPrefab;

    private void Start() {
        SetupDialogueSystem();
        SetupSceneTransition();
    }


    private void SetupSceneTransition()
    {
        Canvas c = Instantiate(transitionPrefab, uiHolder).GetComponent<Canvas>();
        c.worldCamera = Camera.main;       
    }
    private void SetupDialogueSystem() {
        //Create UI
        Canvas dialogueCanvas = CreateCanvas("Dialogue canvas", inventoryCanvasPrefab.gameObject);
        GameObject textPanel = Instantiate(textPanelPrefab, dialogueCanvas.transform);
        GameObject leftImageBox = Instantiate(imageBoxPrefab, dialogueCanvas.transform);
        GameObject rightImageBox = Instantiate(imageBoxPrefab, dialogueCanvas.transform);
        //Position image boxes
        leftImageBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(-730, 0);
        rightImageBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(730, 0);
        //Hide created UI
        dialogueCanvas.gameObject.SetActive(false);
        //Create manager
        DialogueSystem dialogueSystem;
        if (DialogueSystem.inst == null) {
            dialogueSystem = InstantiateManager("Dialogue system", typeof(DialogueSystem),false).GetComponent<DialogueSystem>();
        } else {
            dialogueSystem = DialogueSystem.inst;
        }
        print(dialogueSystem == null);
        dialogueSystem.Setup(symbolDelay, dialogueCanvas, textPanel, leftImageBox, rightImageBox);
    }

    private Canvas CreateCanvas(string name, GameObject canvasPrefab) {
        Canvas canvas = Instantiate(canvasPrefab, uiHolder).GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        canvas.gameObject.name = name;
        return canvas;
    }

    private GameObject InstantiateManager(string name, Type componentType, bool doParent = true) {
        GameObject newObject = new GameObject(name);
        if (doParent) newObject.transform.parent = managerHolder;
        newObject.AddComponent(componentType);
        return newObject;
    }
}
