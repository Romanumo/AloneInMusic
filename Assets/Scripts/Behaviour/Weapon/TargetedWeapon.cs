using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedWeapon : Weapon
{
    private IHealth _targetStats;

    public void Start()
    {
        _targetStats = GetComponent<ITargeted>().target.GetComponent<IHealth>();
    }

    public override void Attack()
    {
        _targetStats.ReceiveDamae(this.attack);
    }
}