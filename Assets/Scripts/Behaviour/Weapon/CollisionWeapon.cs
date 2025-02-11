using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWeapon : Weapon
{
    [SerializeField] private bool deathOnCollision;
    private IHealth target;
    private IKillable owner;

    public void Start()
    {
        if(deathOnCollision)
            owner = GetComponent<IKillable>();
    }

    public override void Attack() 
    {
        target.ReceiveDamae(attack); 
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
            owner.Die();
    }

    protected virtual void CollisionTrigger(GameObject target) { }
}
