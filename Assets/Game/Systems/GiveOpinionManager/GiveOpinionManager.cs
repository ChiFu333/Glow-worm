using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GiveOpinionManager : MonoBehaviour
{
    [SerializeField] private ItemDescriptionSO myDescription;
    [SerializeField] private TMP_Text mainText;
    [SerializeField] private TMP_Text leftButton, rightButton;
    [SerializeField] private SpriteSwapper mainImage;
    [SerializeField] private GameObject panel;

    [SerializeField] private GameObject thinkButton, opinionText;
    private int currentState = 0;
    
    private void Start()
    {
        Init(GameDataStorage.inst.currentOp);
    }
    public void Init(ItemOpinion data)
    {
        myDescription = data.itemData;
        currentState = data.state;
        leftButton.text = myDescription.firstOpinion;
        rightButton.text = myDescription.secondOpinion;
        if(currentState == 0)
        {
            mainImage.UpdateSprite(myDescription.startSprite[0],myDescription.startSprite[1]);
        }
        else if(currentState == 1)
        {
            currentState = 1;
            panel.SetActive(false);
            thinkButton.SetActive(false);
            opinionText.SetActive(true);
            UpdateUI();
        }
        else if(currentState == 2)
        {
            currentState = 2;
            panel.SetActive(false);
            thinkButton.SetActive(false);
            opinionText.SetActive(true);
            UpdateUI();
        }
    }
    public void StartThinking()
    {
        panel.SetActive(true);
        StartCoroutine(WritePhraseText(myDescription.monologe));
    }
    public void ChooseOpinion(int i)
    {
        currentState = i;
        panel.SetActive(false);
        thinkButton.SetActive(false);
        opinionText.SetActive(true);
        UpdateUI();
    }
    private void UpdateUI()
    {
        if(currentState == 1) mainImage.UpdateSprite(myDescription.FirstOpSprite[0],myDescription.FirstOpSprite[1]);
        else if(currentState == 2) mainImage.UpdateSprite(myDescription.SecondOpSprite[0],myDescription.SecondOpSprite[1]);
        GameDataStorage.inst.opInDesc[myDescription] = currentState;
    }
    public IEnumerator WritePhraseText(string message) {
        int count = 0;
        Timer timer = new Timer();
        while (count < message.Length) {
            count++;
            mainText.text = message.Substring(0, count);
            if (count % 4 == 0) {
                //AudioManager.inst.Play(currentPhrase.character.voice);
            }
            timer.SetTime(0.05f);
            while (!timer.Execute()) {
                yield return null;
            }
        }
    }
}
