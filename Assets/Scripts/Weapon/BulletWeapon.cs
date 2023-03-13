using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : Weapon
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float projectileSpeed;
    private Vector3 bulletShootPos;

    void Start()
    {
        bulletShootPos = transform.position + this.transform.forward * 1.5f;
    }

    public override void Attack()
    {
        Instantiate(bullet.gameObject, bulletShootPos, transform.rotation);
    }
}
