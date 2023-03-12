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

        _outVisionRange = () => state = State.Idle;
        _onVisionRange = () => { if (state == State.Idle) state = State.Moving; };
    }

    private void Update()
    {
        CheckTarget();
        if (state == State.Moving)
            _movement.Move();
        else if (state == State.Attacking)
            _weapon.Attack(_target);
    }

    public void CheckTarget()
    {
        if ((transform.position - target.position).sqrMagnitude < rangeSqr)
            onInRange?.Invoke();
        else 
            onOutRange?.Invoke();
    }

    public override void Die()
    {
        throw new NotImplementedException();
    }
}
