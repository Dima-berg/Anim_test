using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStateController : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Hide") || stateInfo.IsName("Null"))
        {
            animator.SetBool("Metamorphosis", false);
        }
        else
        {
            animator.SetBool("Metamorphosis", true);
        }
    }
}
