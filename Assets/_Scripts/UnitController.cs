using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Animator bodyAnimator;
    public Animator soulAnimator;
    public float MetamorphosisTimer = 0.35f;


    void Start ()
    {
        bodyAnimator.Play("Show");
        soulAnimator.Play("Null");
    }
	
	public void Metamorphosis ()
    {
        if (bodyAnimator.GetBool("Metamorphosis"))
        {
            StartCoroutine("MetamorphosisSoul");
        }
        else
        {
            StartCoroutine("MetamorphosisBody");
        }
    }

    IEnumerator MetamorphosisBody ()
    {
        soulAnimator.CrossFade("Hide", 0.25f);
        yield return new WaitForSeconds(MetamorphosisTimer);
        bodyAnimator.CrossFade("Show", 0.25f);        
    }

    IEnumerator MetamorphosisSoul()
    {
        bodyAnimator.CrossFade("Hide", 0.25f);
        yield return new WaitForSeconds(MetamorphosisTimer);
        soulAnimator.CrossFade("Show", 0.25f);
    }
}
