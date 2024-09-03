using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Q", menuName = "ScriptableObject/Question")]
public class QuestionSO : ScriptableObject
{
    public string first, second, third, fourth;
    public int ans;
}
