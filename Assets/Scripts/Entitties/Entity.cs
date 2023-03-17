using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*Between using abstract and interface
As I see
Use abstract when needed inherited objects and they are all almost the same type
interfaces could be used in completely different objects suchh as door and Entity*/

public abstract class Entity : MonoBehaviour, IHealth
{
    [SerializeField] protected int _health;
    protected int _maxHealth;
    protected Behaviour state;

    public int health { get => _health; }
    public int maxHealth { get => _maxHealth; }

    protected void Awake()
    {
        _maxHealth = _health;
    }

    protected virtual void Update()
    {
        state?.UpdateAction();
    }

    public virtual void ModifyHealth(int attack, Weapon sender)
    {
        _health -= attack;
        if (_health < 0)
            Die();
    }

    public void ChangeState(Behaviour state) => this.state = state;

    public abstract void Die();
}

[System.Serializable]
public class RangedState
{
    [HideInInspector] public string _name;
    [SerializeField] private Behaviour _behaviour;
    [SerializeField] private float _range;
    [SerializeField] private string _animationName;
    private float _rangeSqr = -1;

    public float rangeSqr {
        get
        {
            if (_rangeSqr <= 0)
                _rangeSqr = _range * _range;

            return _rangeSqr;
        } }
    public Behaviour behaviour { get => _behaviour; }
    public string animationName { get => _animationName; }

    public RangedState(float rangeSqr, Behaviour state)
    {
        _rangeSqr = rangeSqr;
        _behaviour = state;
        _name = state?.ToString();
    }

    public bool Check(float distSqr)
    {
        if (distSqr < _rangeSqr)
            return true;
        return false;
    }
}