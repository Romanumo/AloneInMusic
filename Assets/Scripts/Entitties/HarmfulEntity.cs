using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmfulEntity : Entity, IAttacker, IWatcher
{
    [SerializeField] private float _noticeDistance;
    private float _noticeDistanceSqr;

    private Weapon _weapon;
    private Transform _target;
    private event Action _onNotice;

    #region Interfaces
    public int attack { get => weapon.attack; }
    public Weapon weapon { get => _weapon; }
    public float noticeDistanceSqr => _noticeDistanceSqr;
    public Transform target => _target;
    public Action onNotice => _onNotice; 
    #endregion

    private new void Start()
    {
        base.Start();

        //Temporarily
        _target = FindObjectOfType<Player>().transform;
        //

        _noticeDistanceSqr = _noticeDistance * _noticeDistance;
        _weapon = this.gameObject.GetComponent<Weapon>();
        _onNotice = () => state = State.Moving;
    }

    private new void Update()
    {
        if (state == State.Moving)
            _movement.Move();
    }

    public void CheckTarget()
    {
        if ((transform.position - target.position).sqrMagnitude < noticeDistanceSqr)
            onNotice?.Invoke();
    }

    public override void Die()
    {
        throw new NotImplementedException();
    }

    public override void ModifyHealth()
    {
        throw new NotImplementedException();
    }
}
