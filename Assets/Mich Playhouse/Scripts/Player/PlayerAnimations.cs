using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations: MonoBehaviour
{
    Animator animator;
    //string currentState;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayerReflectAnim()
    {
        animator.Play("parry");
        //ChangeAnimationState("parry");
    }
    public void IdleAnim()
    {
        animator.Play("Idle");
        //ChangeAnimationState("Idle");
    }
    public void PlayerOuchieAnim()
    {
        animator.SetTrigger("ouchie");
    }


    //void ChangeAnimationState(string newState)
    //{
    //    //if (currentState == newState) return;

    //    animator.Play(newState);

    //    //currentState = newState;
    //}
}
