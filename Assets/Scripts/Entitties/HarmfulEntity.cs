using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmfulEntity : Entity, IAttacker, IWatcher
{
    [SerializeField] private float _visionRange;
    private float _visionRangeSqr;

    private Weapon _weapon;
    private Entity _target;

    private event Action _onVisionRange;
    private event Action _outVisionRange;

    private IEntityState state;

    #region Interfaces
    public int attack { get => weapon.attack; }
    public Weapon weapon { get => _weapon; }
    public float rangeSqr => _visionRangeSqr;
    public Transform target => _target.transform;
    public Action onInRange => _onVisionRange; 
    public Action onOutRange => _outVisionRange;
    #endregion

    private new void Awake()
    {
        base.Awake();

        //Temporarily
        _target = FindObjectOfType<Player>();
        //

        _visionRangeSqr = _visionRange * _visionRange;
        _weapon = this.gameObject.GetComponent<Weapon>();

        _outVisionRange = () => ChangeState(State.Idle);
        _onVisionRange = () => ChangeState(State.Moving);
    }

    private void Update()
    {
        ((IWatcher)this).CheckTarget(transform);
        if (state == State.Attacking)
            _weapon.Attack(_target);
        else if (state == State.Moving)
            _movement.Move();
    }

    public override void ChangeState(State state)
    {
        this.state = state;
    }

    public override void Die()
    {
        throw new NotImplementedException();
    }
}
