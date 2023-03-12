using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IHealth
{
    public int health { get; set; }
    public void Die();
    public void ModifyHealth(int attack, Weapon sender);
}

public interface IEntityState
{
    public void UpdateAction();
}

public interface IWatcher
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
    public Movement movement { get; }
}


// IAttacker with IWeapon interface implementation?