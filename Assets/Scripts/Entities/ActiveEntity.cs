using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEntity : Entity, IStateWatcher
{
    [SerializeField] private List<RangedState> _rangedStates;
    private Animator _animator;
    private Entity _target;

    public Transform target => _target.transform;
    public List<RangedState> rangeStates => _rangedStates;

    private new void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _target = FindObjectOfType<Player>();
    }

    protected override void Update()
    {
        base.Update();
        UpdateState();
    }

    public void UpdateState()
    {
        float distSqr = (transform.position - target.position).sqrMagnitude;
        RangedState state = GameManager.GetPrioritizedState(distSqr, _rangedStates);
        ChangeState(state.behaviour);

        if(state.behaviour != null)
            _animator.Play(state.animationName);
        else
            _animator.Play("Idle");
    }

    public override void Die()
    {
        Destroy(this.gameObject);
    }
}