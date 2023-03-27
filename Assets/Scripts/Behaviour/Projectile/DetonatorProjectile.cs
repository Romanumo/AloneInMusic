using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonatorProjectile : Projectile, IWillDie
{
    private Action onDeath;
    public Action OnDeath { get => onDeath; set => onDeath = value; }

    protected override void Die()
    {
        onDeath?.Invoke();
        base.Die();
    }

    void IWillDie.Die() => Die();
}
