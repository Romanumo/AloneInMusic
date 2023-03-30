using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Behaviour : MonoBehaviour
{
    public abstract void UpdateAction();
}

public abstract class SingleTimeBehavior : Behaviour
{
    protected Action onTrigger;
    public Action OnTrigger { get => onTrigger; set => onTrigger = value; }
}

public interface IWillDie
{
    public Action OnDeath { get; set; }
    public void Die();
}

public interface IHealth : IWillDie
{
    public int health { get; }
    public int maxHealth { get; }

    public Action OnHealthChanged { get; set; }

    public void ModifyHealth(int attack);
}

public interface ITargeted
{
    public Transform target { get; }
}

public interface IStateWatcher : ITargeted
{
    public List<RangedState> rangeStates { get; }
    public void UpdateState();
}

// IAttacker with IWeapon interface implementation?
/*public interface IWatcher
{
    public Transform target { get; }
    public float rangeSqr { get; }
    public Action onInRange { get; }
    public Action onOutRange { get; }

    public void CheckTarget(Transform thisTransfrom)
    {
        if ((thisTransfrom.position - target.position).sqrMagnitude < rangeSqr)
            onInRange?.Invoke();
        else
            onOutRange?.Invoke();
    }
}

public interface IMoveable
{
    public int speed { get; }
}

    public IStateWatcher watcher { get; }
    public float rangeSqr { get; }
*/