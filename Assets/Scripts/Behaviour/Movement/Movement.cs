using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : Behaviour
{
    [SerializeField] protected int _speed;
    public int speed { get => _speed; }
}
