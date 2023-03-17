using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedWeapon : Weapon
{
    private IHealth _targetStats;
    private ITargeted owner;

    public ITargeted watcher => owner;

    public override void Attack()
    {
        _targetStats.ModifyHealth(this.attack, this);
    }

    public void Awake()
    {
        owner = GetComponent<ITargeted>();
        _targetStats = owner.target.GetComponent<IHealth>();
    }
}