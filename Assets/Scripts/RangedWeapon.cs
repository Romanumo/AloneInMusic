using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon, IWatcher
{
    [SerializeField] private float _attackRange;

    private Transform _target;
    private IHealth _targetStats;
    private float _attackRangeSqr;

    private event Action _onAttackRange;
    private event Action _outAttackRange;

    private Entity owner;

    #region Interfaces
    public Transform target => _target;
    public float rangeSqr => _attackRangeSqr;
    public Action onInRange => _onAttackRange;
    public Action onOutRange => _outAttackRange; 
    #endregion

    public void Awake()
    {
        _attackRangeSqr = _attackRange * _attackRange;
        _target = GetComponent<IWatcher>().target;
        _targetStats = _target.GetComponent<IHealth>();

        owner = GetComponent<ActiveEntity>();
        _onAttackRange = () => owner.ChangeState(this);
        _outAttackRange = () => owner.ChangeState(null);
    }

    private void Update()
    {
        ((IWatcher)this).CheckTarget(transform);
    }

    public override void UpdateAction()
    {
        _targetStats.ModifyHealth(this.attack, this);
    }
}