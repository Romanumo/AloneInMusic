using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKnockBack : CollisionWeapon
{
    [SerializeField] private float knockBack;

    protected override void CollisionTrigger(GameObject target)
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Rigidbody rb = target.GetComponent<Rigidbody>();
        rb.velocity = 1000f * knockBack * direction;
        Debug.Log(target.name);
    }
}
