using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private AnimationDataSO standing, walking, thinking;
    private AnimationController playerAnim;
    private float movement = 0;
    private bool isWalking = false;
    private bool isThinking = false;
    private void Start() => playerAnim = GetComponentInChildren<AnimationController>();
    private void Update()
    {
        if(!FindObjectOfType<Player>().inDialoge && !isThinking)
        {
            if(movement != 0) playerAnim.SetFlip(movement < 0);
            if(!isWalking && movement != 0)
            {
                playerAnim.SetAnimation(walking);
                isWalking = true;
                
            }
            else if(isWalking && movement == 0)
            {
                playerAnim.SetAnimation(standing);
                isWalking = false;
            }
        }
        else if(FindObjectOfType<Player>().inDialoge && !isThinking)
        {
            playerAnim.SetAnimation(thinking);
            isThinking = true;
        }
        else if(!FindObjectOfType<Player>().inDialoge && isThinking)
        {
            isThinking = false;
        }
    }
    void FixedUpdate()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }
}
