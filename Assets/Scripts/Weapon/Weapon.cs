using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IBehaviourState
{
    [SerializeField] public int attack;
    [SerializeField] public float reloadTime;
    bool isReloaded = true;

    public void UpdateAction()
    {
        if (isReloaded)
        {
            isReloaded = false;
            StartCoroutine(Reload());
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