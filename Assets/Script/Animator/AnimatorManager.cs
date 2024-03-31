using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup>AnimatorSetup;
    public enum AnimatorType
    {
        RUN,
        IDLE,
        ATTACK,
        JUMP,
        FALL
    }
    public void StartAnimator(AnimatorType Type)
    {
        foreach (var anim in AnimatorSetup)
        {
            if(anim.Type ==Type)
            {
                animator.SetTrigger(anim.Trigger);
                break;
            }

        }

    }

}
[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimatorType Type;
    public string Trigger;
    

}
