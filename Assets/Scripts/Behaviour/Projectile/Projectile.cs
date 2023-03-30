using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IWillDie
{
    [SerializeField] protected float liveTime;

    public int attack { get; protected set; }
    public Entity sender { get; protected set; }

    public Action OnDeath { get => onDeath; set => onDeath = value; }
    private Action onDeath;

    protected void Awake()
    {
        StartCoroutine(Despawn());
    }

    public virtual void AssignBullet(Entity sender, int attack, float bulletSpeed)
    {
        this.attack = attack;
        this.sender = sender;
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(liveTime);
        Die();
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
