using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameDataStorage : MonoBehaviour
{
    public static GameDataStorage inst { get; private set; }
    private void Awake() {
        if (inst != null && inst != this) {
            Destroy(this);
        } else {
            inst = this;
            DontDestroyOnLoad(gameObject);
            opInDesc = new Dictionary<ItemDescriptionSO, int>();
            for(int i = 0; i < Opinions.Count; i++) opInDesc.Add(Opinions[i],0);
            currentOp = new ItemOpinion(Opinions[0],opInDesc[Opinions[0]]);
        }
    }
    [HideInInspector] public ItemOpinion currentOp;
    public List<ItemDescriptionSO> Opinions;
    public Dictionary<ItemDescriptionSO, int> opInDesc;
}
