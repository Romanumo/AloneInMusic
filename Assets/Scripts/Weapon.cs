using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int attack { get; set; }
    public abstract void Attack(Entity entity);
}

public class RadiusWeapon : Weapon
{
    public int attack { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Attack(Entity entity)
    {
        throw new System.NotImplementedException();
    }
}