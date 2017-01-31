using Spine.Unity.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSkeletonGhost : SkeletonGhost
{
	public void Start ()
    {
        base.Start();
        ghostingEnabled = false;
    }
}
