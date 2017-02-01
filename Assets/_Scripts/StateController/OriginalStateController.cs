using Spine.Unity.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalStateController : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("Show") && !stateInfo.IsName("HideIdle") && !stateInfo.IsName("Show"))
        {
            if (!stateInfo.IsName("Dead") && !stateInfo.IsName("DeadIdle") && !stateInfo.IsName("Rise") && animator.GetBool("Dead"))
            {
                Dead(animator);
            }

            if (stateInfo.IsName("Rise"))
            {
                if (stateInfo.normalizedTime >= 0.75f)
                {
                    CurrentState(animator);
                }
            }

            if (stateInfo.IsName("Ground"))
            {
                if (stateInfo.normalizedTime >= 0.75f)
                {
                    CurrentState(animator);
                }
            }

            if (!stateInfo.IsName("Jump") && !stateInfo.IsName("Fly") && !animator.GetBool("Ground") && animator.GetFloat("ySpeed") > 1)
            {
                Jump(animator);
            }

            if (!stateInfo.IsName("Fail") && !animator.GetBool("Ground") && animator.GetFloat("ySpeed") < 1)
            {
                Fail(animator);
            }
        }

        if (stateInfo.IsName("Show"))
        {
            if (stateInfo.normalizedTime >= 0.3f)
            {
                CurrentState(animator);
            }
        }

        if (!stateInfo.IsName("Hide") && !stateInfo.IsName("HideIdle") && !animator.GetBool("Show"))
        {
            Hide(animator);
        }
    }

    void Hide(Animator animator)
    {
        animator.CrossFade("Hide", 0.25f);
    }

    void Dead (Animator animator)
    {
        animator.CrossFade("Dead", 0.25f);
    }

    void Jump(Animator animator)
    {
        animator.CrossFade("Jump", 0.25f);
    }

    void Fail(Animator animator)
    {
        animator.CrossFade("Fail", 0.25f);
    }

    void CurrentState (Animator animator)
    {
        if (animator.GetBool("Ground") && !animator.GetBool("Wall"))
        {
            if (animator.GetBool("StartRound"))
            {
                if (animator.GetFloat("xSpeed") > 0)
                {
                    animator.CrossFade("Run", 0.25f);
                }
                else
                {
                    animator.CrossFade("Idle", 0.25f);
                }
            }
            else
            {
                animator.CrossFade("Start", 0.25f);                
            }
        }

        if (animator.GetBool("Ground") && animator.GetBool("Wall"))
        {
            animator.CrossFade("Wall", 0.25f);
        }

        if (!animator.GetBool("Ground"))
        {
            if (animator.GetFloat("ySpeed") > 1)
            {
                animator.CrossFade("Fly", 0.25f);
            }
            else
            {
                animator.CrossFade("Fail", 0.25f);
            }
        }
    }
}
