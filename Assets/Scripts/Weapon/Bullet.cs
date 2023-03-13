using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int attack;
    private Weapon weapon;
    private Movement movement;

    private void Start()
    {
        movement = GetComponent<Movement>();
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
    }
}
