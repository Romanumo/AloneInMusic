using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IWillDie
{
    [SerializeField] protected float liveTime;
    protected float bulletSpeed;
    public int attack { get; protected set; }

    public Action OnDeath { get => onDeath; set => onDeath = value; }
    private Action onDeath;

    protected void Awake()
    {
        StartCoroutine(Despawn());
    }

    public virtual void AssignBullet(int attack, float bulletSpeed)
    {
        this.attack = attack;
        this.bulletSpeed = bulletSpeed;
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(liveTime);
        Die();
    }

    public virtual void Die()
    {
        onDeath?.Invoke();
        Destroy(this.gameObject);
    }
}
