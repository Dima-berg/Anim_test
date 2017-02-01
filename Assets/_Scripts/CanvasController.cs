using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : Singleton<CanvasController>
{
    public ParticleSystem particleSystem;

    [Header("Animators")]
    public Animator animatorBody;
    public Animator animatorSoul;
    public Animator animatorSmoke;
    public Animator animatorMask;

    [Header("Animator parameters")]
    public bool animatorGround = true;
    public bool animatorWall = false;
    public float animatorXSpeed = 1.0f;
    public float animatorYSpeed = 0.0f;
    public bool animatorDead = false;
    public bool animatorShow = true;
    public bool animatorStartRound = false;
    public int animatorFinish = -1;
    public bool animatorAttack = false;
    public bool animatorInvisibility = false;

    [Header("Canvas parameters")]
    public Toggle canvasGround;
    public Toggle canvasWall;
    public InputField canvasXSpeed;
    public InputField canvasYSpeed;
    public Toggle canvasDead;
    public Toggle canvasShow;
    public Toggle canvasStartRound;
    public InputField canvasFinish;
    public Toggle canvasAttack;
    public Toggle canvasInvisibility;

    void Start ()
    {
        SetAnimatorParametrs();
        SetCanvasParametrs();
    }
	
	void Update ()
    {
        SetAnimatorParametrs();
        SetCanvasParametrs();
    }

    public void SetParametrs()
    {
        animatorGround = canvasGround.isOn;
        animatorWall = canvasWall.isOn;
        animatorXSpeed = float.Parse(canvasXSpeed.text);
        animatorYSpeed = float.Parse(canvasYSpeed.text);
        animatorDead = canvasDead.isOn;
        if (animatorShow != canvasShow.isOn)
        {
            particleSystem.Play();
        }
        animatorShow = canvasShow.isOn;
        animatorStartRound = canvasStartRound.isOn;
        animatorFinish = int.Parse(canvasFinish.text);
        animatorAttack = canvasAttack.isOn;
        animatorInvisibility = canvasInvisibility.isOn;        
    }

    void SetCanvasParametrs ()
    {
        canvasGround.isOn = animatorGround;
        canvasWall.isOn = animatorWall;
        canvasXSpeed.text = animatorXSpeed.ToString();
        canvasYSpeed.text = animatorYSpeed.ToString();
        canvasDead.isOn = animatorDead;
        if (animatorShow != canvasShow.isOn)
        {
            particleSystem.Play();
        }
        canvasShow.isOn = animatorShow;
        canvasStartRound.isOn = animatorStartRound;
        canvasFinish.text = animatorFinish.ToString();
        canvasAttack.isOn = animatorAttack;
        canvasInvisibility.isOn = animatorInvisibility;
    }

    void SetAnimatorParametrs ()
    {
        //Значение для аниматора Body
        animatorBody.SetBool("Ground", animatorGround);
        animatorBody.SetBool("Wall", animatorWall);
        animatorBody.SetFloat("xSpeed", animatorXSpeed);
        animatorBody.SetFloat("ySpeed", animatorYSpeed);
        animatorBody.SetBool("Dead", animatorDead);
        animatorBody.SetBool("Show", animatorShow);
        animatorBody.SetBool("StartRound", animatorStartRound);
        animatorBody.SetInteger("Finish", animatorFinish);
        animatorBody.SetBool("Attack", animatorAttack);
        animatorBody.SetBool("Invisibility", animatorInvisibility);

        //Значение для аниматора Soul
        animatorSoul.SetBool("Ground", animatorGround);
        animatorSoul.SetBool("Wall", animatorWall);
        animatorSoul.SetFloat("xSpeed", animatorXSpeed);
        animatorSoul.SetFloat("ySpeed", animatorYSpeed);
        animatorSoul.SetBool("Dead", animatorDead);
        animatorSoul.SetBool("Show", !animatorShow);
        animatorSoul.SetBool("StartRound", animatorStartRound);
        animatorSoul.SetInteger("Finish", animatorFinish);
        animatorSoul.SetBool("Attack", animatorAttack);
        animatorSoul.SetBool("Invisibility", animatorInvisibility);

        //Значение для аниматора Smoke
        animatorSmoke.SetBool("Smoke", animatorSoul.GetBool("Invisibility"));

        //Значение для аниматора Mask
        animatorMask.SetBool("Attack", animatorAttack);
        animatorMask.SetBool("Show", animatorShow);
        animatorAttack = false;
    }

    public void TimeScale (float _timeScale)
    {
        Time.timeScale = _timeScale;
    }
}
