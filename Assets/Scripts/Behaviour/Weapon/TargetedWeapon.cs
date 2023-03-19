using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedWeapon : Weapon
{
    private IHealth _targetStats;

    public override void Attack()
    {
        _targetStats.ModifyHealth(this.attack, owner);
    }

    public void Start()
    {
        _targetStats = ((ITargeted)owner).target.GetComponent<IHealth>();
    }
}