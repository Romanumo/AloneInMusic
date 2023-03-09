using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public int attack;
    [SerializeField] LayerMask atttackableLayer;
    public abstract void Attack(Entity entity);
}