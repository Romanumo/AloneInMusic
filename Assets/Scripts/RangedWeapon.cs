using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private float _attackRange;

    private Transform _target;
    private IHealth _targetStats;
    private float _attackRangeSqr;

    private IStateWatcher owner;

    public void Awake()
    {
        _attackRangeSqr = _attackRange * _attackRange;
        owner = GetComponent<IStateWatcher>();
        _target = owner.target;
        _targetStats = _target.GetComponent<IHealth>();

        owner.AddState(_attackRangeSqr, this);
    }

    public override void UpdateAction()
    {
        _targetStats.ModifyHealth(this.attack, this);
    }
}