using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float liveTime;
    [SerializeField] private ParticleSystem collisionEffect;

    private int attack;
    private Weapon weapon;
    private Movement movement;

    private void Start()
    {
        movement = GetComponent<Movement>();
        StartCoroutine(Despawn());
    }

    void Update()
    {
        movement.UpdateAction();   
    }

    public void AssignBullet(int attack, Weapon weapon)
    {
        this.attack = attack;
        this.weapon = weapon;
    }

    public void OnCollisionEnter(Collision collision)
    {
        IHealth health;
        if (collision.gameObject.TryGetComponent<IHealth>(out health))
        {
            health.ModifyHealth(attack, weapon);
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
