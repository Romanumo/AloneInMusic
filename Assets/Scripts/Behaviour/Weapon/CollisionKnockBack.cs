using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKnockBack : CollisionWeapon
{
    [SerializeField] private float knockBack;

    protected override void CollisionTrigger(GameObject target)
    {
        Vector3 direction = (target.transform.position - transform.position + new Vector3(0, 3, 0)).normalized;
        Rigidbody rb;
        if (target.TryGetComponent(out rb))
            rb.velocity = knockBack * direction;
        else
            target.GetComponent<Player>().Knockback(knockBack * direction);
    }
}
