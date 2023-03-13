using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedWeapon : Weapon
{
    [SerializeField] private float _attackRange;

    private IHealth _targetStats;
    private float _attackRangeSqr;

    private IStateWatcher owner;

    public override void Attack()
    {
        _targetStats.ModifyHealth(this.attack, this);
    }

    public void Awake()
    {
        _attackRangeSqr = _attackRange * _attackRange;
        owner = GetComponent<IStateWatcher>();
        _targetStats = owner.target.GetComponent<IHealth>();

        owner.AddState(_attackRangeSqr, this);
    }
}