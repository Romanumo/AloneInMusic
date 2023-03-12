using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon, IWatcher
{
    [SerializeField] private float _attackRange;

    private Transform _target;
    private float _attackRangeSqr;

    private event Action _onAttackRange;
    private event Action _outAttackRange;

    private HarmfulEntity owner;

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

        owner = GetComponent<HarmfulEntity>();
        _onAttackRange = () => owner.ChangeState(State.Attacking);
        _outAttackRange = () => owner.ChangeState(State.Moving);
    }

    private void Update()
    {
        ((IWatcher)this).CheckTarget(transform);
    }

    public override void Attack(IHealth damageableObject)
    {
        damageableObject.ModifyHealth(this.attack, this);
    }
}