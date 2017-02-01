using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMask : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = new Vector3(-1,1,0);

    void Update ()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.position + offset, Time.deltaTime);
    }
}
