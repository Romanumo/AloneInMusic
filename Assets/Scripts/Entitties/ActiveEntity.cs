using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEntity : Entity, IStateWatcher
{
    [SerializeField] private float _visionRange;
    private float _visionRangeSqr;

    private Entity _target;

    private event Action _onVisionRange;
    private event Action _outVisionRange;

    private Dictionary<float, IEntityState> _rangeStates;

    #region Interfaces
    public float rangeSqr => _visionRangeSqr;
    public Transform target => _target.transform;
    public Action onInRange => _onVisionRange; 
    public Action onOutRange => _outVisionRange;
    public Dictionary<float, IEntityState> rangeStates => _rangeStates;
    #endregion

    private new void Awake()
    {
        base.Awake();

        //Temporarily
        _target = FindObjectOfType<Player>();
        //

        _visionRangeSqr = _visionRange * _visionRange;

        _outVisionRange = () => stateAction = null;
        _onVisionRange = () => stateAction = movement;
    }

    private void Update()
    {
        base.Update();
        ((IWatcher)this).CheckTarget(transform);
    }

    public override void Die()
    {
        throw new NotImplementedException();
    }
}
