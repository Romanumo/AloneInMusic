using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Movement
{
    private Transform target;

    private void Start()
    {
        target = GetComponent<ITargeted>().target;
    }

    public override void UpdateAction()
    {
        this.transform.LookAt(target, Vector3.up);
        this.transform.position += transform.forward * speed * Time.deltaTime;
    }
}
