using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : SingleTimeBehavior
{
    [SerializeField] public int attack;
    [SerializeField] public float reloadTime;
    protected Entity _owner;
    bool isReloaded = true;

    public Entity owner { get; }

    private void Awake()
    {
        _owner = GetComponent<Entity>();
    }

    public override void UpdateAction()
    {
        if (isReloaded)
        {
            isReloaded = false;
            StartCoroutine(Reload());
            onTrigger?.Invoke();
            Attack();
        }
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        isReloaded = true;
        yield return null;
    }

    public abstract void Attack();
}