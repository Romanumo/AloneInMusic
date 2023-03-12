using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Between using abstract and interface
As I see
Use abstract when needed inherited objects and they are all almost the same type
interfaces could be used in completely different objects suchh as door and Entity*/

public abstract class Entity : MonoBehaviour, IHealth, IMoveable
{
    [SerializeField] protected int _health;
    protected Movement _movement;
    protected IBehaviourState stateAction;

    public int health { get => _health; set => _health = value; }
    public int speed { get => _movement.speed; }
    public Movement movement => _movement;

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
        Debug.Log(this.gameObject.name + " Received damage from " + sender.gameObject.name);
        health -= attack;
    }

    public void ChangeState(IBehaviourState state) => this.stateAction = state;

    public abstract void Die();
}

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