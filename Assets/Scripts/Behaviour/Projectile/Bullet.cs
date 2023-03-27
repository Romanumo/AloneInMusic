using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] private ParticleSystem collisionEffect;
    private Movement movement;

    private new void Awake()
    {
        base.Awake();
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        movement.UpdateAction();   
    }

    public override void AssignBullet(Entity sender, int attack, float bulletSpeed)
    {
        base.AssignBullet(sender, attack, bulletSpeed);
        movement.speed = bulletSpeed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        IHealth health;
        if (collision.gameObject.TryGetComponent(out health))
            health.ModifyHealth(attack, sender);

        FXManager.CreateEffect(collisionEffect, transform);
        Die();
    }
}