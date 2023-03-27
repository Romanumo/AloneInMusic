using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float liveTime;

    public int attack { get; protected set; }
    public Entity sender { get; protected set; }

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

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
