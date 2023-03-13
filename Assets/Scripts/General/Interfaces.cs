using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IHealth
{
    public int health { get; }
    public void Die();
    public void ModifyHealth(int attack, Weapon sender);
}

public interface IBehaviourState
{
    public void UpdateAction();
}

public interface ITargeted
{
    public Transform target { get; }
}

public interface IStateWatcher : ITargeted
{
    public List<RangedState> rangeStates { get; }
    public void AddState(float range, IBehaviourState state);
    public IBehaviourState GetPrioritizedState();
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
*/