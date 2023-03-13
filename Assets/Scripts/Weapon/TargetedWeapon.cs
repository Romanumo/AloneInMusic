using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedWeapon : Weapon, IRanged
{
    [SerializeField] private float _attackRange;

    private IHealth _targetStats;
    private float _attackRangeSqr;
    private IStateWatcher owner;

    public IStateWatcher watcher => owner;
    public float rangeSqr => _attackRangeSqr;

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