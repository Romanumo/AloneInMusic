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

    public Transform target => _target;
    public float rangeSqr => _attackRangeSqr;
    public Action onInRange => _onAttackRange;
    public Action onOutRange => _outAttackRange;

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
        CheckTarget();
    }

    public override void Attack(Entity entity)
    {
        entity.ModifyHealth(this.attack, this);
    }

    public void CheckTarget()
    {
        if ((transform.position - target.position).sqrMagnitude < rangeSqr)
            onInRange?.Invoke();
        else
            onOutRange?.Invoke();
    }
}