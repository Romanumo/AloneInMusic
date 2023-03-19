using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float liveTime;
    [SerializeField] private ParticleSystem collisionEffect;

    private int attack;

    private Entity sender;
    private Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        StartCoroutine(Despawn());
    }

    void Update()
    {
        movement.UpdateAction();   
    }

    public void AssignBullet(Entity sender, int attack, float bulletSpeed)
    {
        this.attack = attack;
        this.sender = sender;
        movement.speed = bulletSpeed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        IHealth health;
        if (collision.gameObject.TryGetComponent<IHealth>(out health))
        {
            health.ModifyHealth(attack, sender);
        }
        FXManager.CreateEffect(collisionEffect, transform);
        Die();
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(liveTime);
        Die();
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}