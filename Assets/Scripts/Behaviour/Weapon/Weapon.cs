using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Behaviour, ISingleTimeBehavior
{
    [SerializeField] public int attack;
    [SerializeField] public float reloadTime;
    bool isReloaded = true;
    Action onTrigger;

    public Action OnTrigger { get => OnTrigger; set => onTrigger = value; }

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

    public abstract void Attack();

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        isReloaded = true;
        yield return null;
    }
}