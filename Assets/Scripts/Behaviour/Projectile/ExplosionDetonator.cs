using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDetonator : MonoBehaviour
{
    //[SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private Projectile projectileStats;
    [SerializeField] private float explosionRadius;
    private IKillable detonator;

    void Start()
    {
        detonator = GetComponent<IKillable>();
        detonator.OnDeath += Explosion;
    }

    private void Explosion()
    {
        //GameManager.CreateEffect(explosionEffect, transform.position);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            IHealth health;
            hitCollider.gameObject.TryGetComponent(out health);
            health?.ReceiveDamage(projectileStats.attack);
        }
    }
}
