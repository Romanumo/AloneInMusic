using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWeapon : Weapon
{
    [SerializeField] private bool deathOnCollision;
    private IHealth target;

    public override void Attack() 
    {
        target.ReceiveDamage(attack); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        IHealth health;

        if (collision.gameObject.TryGetComponent(out health))
        {
            target = health;
            UpdateAction();
            CollisionTrigger(collision.gameObject);
        }

        if (deathOnCollision)
        {
            IKillable owner;
            if (TryGetComponent<IKillable>(out owner))
            {
                owner.Die();
            }
        }
    }

    protected virtual void CollisionTrigger(GameObject target) { }
}
