using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemDescriptionData", menuName = "ScriptableObjects/ItemDescriptionData")]
public class ItemDescriptionSO : ScriptableObject
{
    public Sprite[] startSprite = new Sprite[2];
    public Sprite[] FirstOpSprite = new Sprite[2];
    public Sprite[] SecondOpSprite = new Sprite[2];
    [Multiline] public string monologe;
    public string firstOpinion, secondOpinion;
}
[System.Serializable]
public class ItemOpinion
{
    public ItemDescriptionSO itemData;
    public int state = 0;
    public ItemOpinion(ItemDescriptionSO d, int s) 
    {
        itemData = d;
        state = s;
    }
}