using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMask : MonoBehaviour
{
    public Transform target;

	void Update ()
    {
        this.transform.LookAt(this.transform.position + Vector3.forward);
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.position + new Vector3(-1,1,0), Time.deltaTime);
    }
}
