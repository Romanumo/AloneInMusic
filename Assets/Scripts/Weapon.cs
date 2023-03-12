using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IEntityState
{
    [SerializeField] public int attack;
    [SerializeField] LayerMask atttackableLayer;

    public abstract void UpdateAction();
}