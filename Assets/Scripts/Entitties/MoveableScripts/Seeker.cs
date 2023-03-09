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
        this.transform.LookAt(target);
        this.transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
    }
}
