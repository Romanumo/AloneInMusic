using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Movement
{
    private Transform target;

    private void Start()
    {
        target = GetComponent<IWatcher>().target;
    }

    public override void Move()
    {
        this.transform.LookAt(target, Vector3.up);
        this.transform.position += transform.forward * speed * Time.deltaTime;
    }
}
