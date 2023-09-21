using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations: MonoBehaviour
{
    Animator animator;
    string currentState;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Idle");
    }

    public void Parry()
    {
        animator.Play("parry");
        //ChangeAnimationState("parry");
    }
    public void Idle()
    {
        ChangeAnimationState("Idle");
    }
    public void TakeDamage()
    {
        ChangeAnimationState("Take_DMG");
    }
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
}
