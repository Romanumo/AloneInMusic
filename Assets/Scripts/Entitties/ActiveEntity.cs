using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEntity : Entity, IStateWatcher
{
    [SerializeField] private float _visionRange;
    private float _visionRangeSqr;

    private Entity _target;
    private List<RangedState> _rangedStates;

    #region Interfaces
    public Transform target => _target.transform;
    public List<RangedState> rangeStates => _rangedStates;
    #endregion

    private new void Awake()
    {
        base.Awake();

        //Temporarily
        _target = FindObjectOfType<Player>();
        //

        _visionRangeSqr = _visionRange * _visionRange;

        _rangedStates = new List<RangedState>();
        _rangedStates.Add(new RangedState(_visionRangeSqr, movement));
    }

    private void Update()
    {
        base.Update();
        ChangeState(GetPrioritizedState());
    }

    public IBehaviourState GetPrioritizedState()
    {
        float distSqr = (transform.position - target.position).sqrMagnitude;
        RangedState lastRangedState = new RangedState(distSqr, null);
        foreach (RangedState state in _rangedStates)
        {
            bool isWithin = state.Check(distSqr);
            bool isMorePrioritized = (state.range < lastRangedState.range || lastRangedState.state == null);
            if (isWithin && isMorePrioritized)
                lastRangedState = state;
        }
        return lastRangedState.state;
    }

    public void AddState(float range, IBehaviourState state) => _rangedStates.Add(new RangedState(range, state));

    public override void Die()
    {
        throw new NotImplementedException();
    }
}