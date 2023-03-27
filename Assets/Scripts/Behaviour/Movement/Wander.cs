using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Movement
{
    [SerializeField] private float sightRange;
    private float angle = 0;

    public override void UpdateAction()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + transform.forward * 1.5f, transform.forward, out hit, sightRange))
        {
            Random.InitState(System.DateTime.UtcNow.Millisecond);
            angle = Random.Range(0, 360);
        }

        this.transform.position += transform.forward * speed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), 100f * Time.deltaTime);
    }
}
