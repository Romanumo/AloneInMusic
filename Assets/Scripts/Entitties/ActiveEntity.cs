using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEntity : Entity, IStateWatcher
{
    [SerializeField] private List<RangedState> _rangedStates;
    private Entity _target;

    public Transform target => _target.transform;
    public List<RangedState> rangeStates => _rangedStates;

    private new void Awake()
    {
        base.Awake();
        _target = FindObjectOfType<Player>();
    }

    private void Update()
    {
        base.Update();
        ChangeState(GetPrioritizedState());
        for (int i = 0; i < _rangedStates.Count; i++)
            Debug.Log(i + " " + _rangedStates[i].state);
    }

    public IBehaviourState GetPrioritizedState()
    {
        float distSqr = (transform.position - target.position).sqrMagnitude;
        RangedState lastRangedState = new RangedState(distSqr, null);
        foreach (RangedState state in _rangedStates)
        {
            bool isWithin = state.Check(distSqr);
            bool isMorePrioritized = (state.rangeSqr < lastRangedState.rangeSqr || lastRangedState.state == null);
            if (isWithin && isMorePrioritized)
                lastRangedState = state;
        }
        return lastRangedState.state;
    }

    public void UpdateBehavioursList()
    {
        _rangedStates = new List<RangedState>();
        IBehaviourState[] states = GetComponents<IBehaviourState>();
        foreach (IBehaviourState state in states)
        {
            _rangedStates.Add(new RangedState(0, state));
        }
    }

    public override void Die()
    {
        Destroy(this.gameObject);
    }

    public void AddState(float range, IBehaviourState state) => _rangedStates.Add(new RangedState(range, state));
}