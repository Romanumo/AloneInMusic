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
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject.GetComponent<IHealth>();
            UpdateAction();
        }
    }
}
