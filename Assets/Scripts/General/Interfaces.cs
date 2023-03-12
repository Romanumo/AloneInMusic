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

public interface IWatcher
{
    public Transform target { get; }
    public Watcher watcher { get; }
}

public interface IMoveable
{
    public int speed { get; }
    public Movement movement { get; }
}

public interface IAttacker
{
    public int attack { get; }
    public Weapon weapon { get; }
}

// IAttacker with IWeapon interface implementation?