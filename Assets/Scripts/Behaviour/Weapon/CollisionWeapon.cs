using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWeapon : Weapon
{
    private IHealth target;

    public override void Attack() 
    {
        target.ModifyHealth(attack, _owner); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        IHealth health;
        if (collision.gameObject.TryGetComponent(out health))
        {
            target = health;
            UpdateAction();
        }
    }
}
