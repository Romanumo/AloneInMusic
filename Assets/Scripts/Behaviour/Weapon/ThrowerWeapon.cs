using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerWeapon : Weapon
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private bool lookAtTargetWhileShooting = true;
    [SerializeField] private Projectile projectile;
    [SerializeField] private Transform shootPoint;

    private ITargeted owner;
    private Transform shootTransform;

    private void Start()
    {
        owner = GetComponent<ITargeted>();
        shootTransform = (shootPoint == null) ? transform : shootPoint;
    }

    public override void Attack()
    {
        if(lookAtTargetWhileShooting)
            transform.LookAt(owner.target);
        Vector3 shootPosition = shootTransform.position + this.transform.forward * 1.5f;

        Shoot(shootPosition);
    }

    protected virtual void Shoot(Vector3 shootPosition)
    {
        Projectile projectileInstance = Instantiate<Projectile>(projectile, shootPosition, shootPoint.rotation);
        projectileInstance.AssignBullet(attack, bulletSpeed);
    }
}
