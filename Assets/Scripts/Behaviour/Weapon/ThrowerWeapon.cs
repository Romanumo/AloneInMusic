using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerWeapon : Weapon
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private bool lookAtTargetWhileShooting = true;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform shootPoint;
    private Transform shootTransform;

    private void Start()
    {
        shootTransform = (shootPoint == null) ? transform : shootPoint;
    }

    public override void Attack()
    {
        if(lookAtTargetWhileShooting)
            transform.LookAt(((ITargeted)owner).target);
        Vector3 shootPosition = shootTransform.position + this.transform.forward * 1.5f;

        Bullet bulletInstance = Instantiate<Bullet>(bullet, shootPosition, shootTransform.rotation);
        bulletInstance.AssignBullet(owner, attack, bulletSpeed);
    }
}
