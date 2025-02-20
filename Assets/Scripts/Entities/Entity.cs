using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

/*Between using abstract and interface. As I see
Use abstract when needed inherited objects and they are all almost the same type
interfaces could be used in completely different objects suchh as door and Entity*/

public abstract class Entity : MonoBehaviour, IHealth
{
    [SerializeField] protected int _maxHealth;
    protected int _health;

    protected Action onHealthChanged;
    protected Action onDeath;
    protected Behaviour currentBehavior;

    public int health { get => _health; }
    public int maxHealth { get => _maxHealth; }
    public Action OnHealthChanged { get => onHealthChanged; set => onHealthChanged = value; }
    public Action OnDeath { get => onDeath; set => onDeath = value; }
    public void ChangeState(Behaviour state) => currentBehavior = state;

    protected void Awake()
    {
        _health = _maxHealth;
        onDeath += Die;
    }

    protected virtual void Update()
    {
        currentBehavior?.UpdateAction();
    }

    public void ReceiveDamage(int attack)
    {
        _health -= attack;

        onHealthChanged?.Invoke();

        if (_health < 0)
            onDeath?.Invoke();
    }

    public abstract void Die();

    public Entity() { }
}   