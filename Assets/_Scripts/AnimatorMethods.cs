using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMethods : MonoBehaviour
{
    public ParticleSystem ParticleSystemCatHeadSmoke;
    public ParticleSystem ParticleSystemCatHeadLights;
    public ParticleSystem ParticleSystemMaskAttackParticleCircle;
    public Animator animator;
    public Animator AnimatorMaskAttackWawe;

    void Start()
    {
        if (ParticleSystemCatHeadSmoke && ParticleSystemCatHeadLights)
        {
            ParticleSystemCatHeadStop();
        }
    }

    void Update()
    {
        if (ParticleSystemCatHeadSmoke && ParticleSystemCatHeadLights)
        {
            if (animator.GetBool("Invisibility") && ParticleSystemCatHeadSmoke.isStopped && ParticleSystemCatHeadLights.isStopped)
            {
                ParticleSystemCatHeadPlay();
            }
            if (!animator.GetBool("Invisibility") && ParticleSystemCatHeadSmoke.isPlaying && ParticleSystemCatHeadLights.isPlaying)
            {
                ParticleSystemCatHeadStop();
            }
        }

        if (AnimatorMaskAttackWawe)
        {
            if (animator.GetBool("Attack"))
            {
                MaskAttack();
            }
        }
    } 

    public void ParticleSystemCatHeadPlay ()
    {
        ParticleSystemCatHeadSmoke.Play();
        ParticleSystemCatHeadLights.Play();
    }

    public void ParticleSystemCatHeadStop()
    {
        ParticleSystemCatHeadSmoke.Stop();
        ParticleSystemCatHeadLights.Stop();
    }

    public void MaskAttack ()
    {
        ParticleSystemMaskAttackParticleCircle.Play();
        AnimatorMaskAttackWawe.SetTrigger("Attack");
    }
}
