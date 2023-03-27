using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : ThrowerWeapon
{
    [SerializeField] private int projectileAmount;
    [SerializeField] private float bulletSpread;

    protected override void Shoot(Vector3 shootPosition)
    {
        for (int i = 0; i < projectileAmount; i++)
        {
            Random.InitState(System.DateTime.UtcNow.Millisecond);
            Vector3 shootAlteration = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.1f, 0.1f), Random.Range(0, 1f)) * bulletSpread;
            /*shootDirection = transform.forward + shootAlteration;
            base.Shoot(shootPosition + shootAlteration, shootDirection);*/
        }
    }
}
