using System;
using UnityEngine;


public class AnimationController
{
    private readonly Animator animator;
    public AnimationController(Animator animator)
    {
        this.animator = animator;
    }

    public void ChangeCurrentState(string nextState)
    {
        Logger.LogWarning($"current state information {animator.GetCurrentAnimatorStateInfo(0)}");
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(nextState)) return;
        animator.Play(nextState);
    }
}
