using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAnswerCanvas : MonoBehaviour
{
    public Transform Startpos;
    public static EndAnswerCanvas inst { get; private set; }
    public GameObject canvas, TPcanvas;
    public List<IdButtons> buttons = new List<IdButtons>();
    public List<QuestionSO> questions;
    public List<DialogueSO> EgoDialog;
    public DialogueSO angryAnswer;
    private void Awake() {
        if (inst != null && inst != this) {
            Destroy(this);
        } else {
            inst = this;
        }
    }
    public int currentQuestion = 0;
    public void ChangeActive(bool b)
    {
        canvas.SetActive(b);
    }
    public void AskQuestion(int id)
    {
        currentQuestion = id;
        ChangeActive(true);
        buttons[0].UpdateUI(questions[id].first);
        buttons[1].UpdateUI(questions[id].second);
        buttons[2].UpdateUI(questions[id].third);
        buttons[3].UpdateUI(questions[id].fourth);
    }
    public void GiveAnswer(IdButtons b)
    {
        ChangeActive(false);
        DialogueSystem.inst.Pause(false);
        if(b.id == questions[currentQuestion].ans)
        {
            DialogueSystem.inst.StartDialogue(EgoDialog[currentQuestion]);
        }
        else
        {
            DialogueSystem.inst.StartDialogue(angryAnswer);
        }
    }
    public void SetTPCanvasActive(bool b) => TPcanvas.SetActive(b);
    public void Teleport()
    {
        FindObjectOfType<Player>().transform.position = Startpos.position;
        FindObjectOfType<Player>().transform.rotation = Startpos.rotation;
    }
}
