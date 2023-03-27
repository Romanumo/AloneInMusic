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

    protected Action onHealthChanged;
    protected Action onDeath;

    public int health { get => _health; }
    public int maxHealth { get => _maxHealth; }
    public Action OnHealthChanged { get => onHealthChanged; set => onHealthChanged = value; }
    public Action OnDeath { get => onDeath; set => onDeath = value; }

    protected void Awake()
    {
        _maxHealth = _health;
        onDeath += Die;
    }

    protected virtual void Update()
    {
        state?.UpdateAction();
    }

    public void ModifyHealth(int attack, Entity sender)
    {
        _health -= attack;
        onHealthChanged?.Invoke();
        if (_health < 0)
            onDeath.Invoke();
    }

    public void ChangeState(Behaviour state) => this.state = state;
    public abstract void Die();
    public Entity() { }
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