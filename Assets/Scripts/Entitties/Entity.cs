using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Between using abstract and interface
As I see
Use abstract when needed inherited objects and they are all almost the same type
interfaces could be used in completely different objects suchh as door and Entity*/

public abstract class Entity : MonoBehaviour, IHealth
{
    [SerializeField] protected int _health;
    protected Movement _movement;
    protected IBehaviourState stateAction;

    public int health { get => _health; }

    protected void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    protected virtual void Update()
    {
        stateAction?.UpdateAction();
    }

    public virtual void ModifyHealth(int attack, Weapon sender)
    {
        _health -= attack;
        if (_health < 0)
            Die();
    }

    public void ChangeState(IBehaviourState state) => this.stateAction = state;

    public abstract void Die();
}

[System.Serializable]
public class RangedState
{
    public float range;
    public IBehaviourState state;

    public RangedState(float range, IBehaviourState state)
    {
        this.range = range;
        this.state = state;
    }

    public bool Check(float dist)
    {
        if (dist < range)
            return true;
        return false;
    }
}