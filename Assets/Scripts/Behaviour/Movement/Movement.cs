using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : Behaviour
{
    [SerializeField] protected float _speed;
    public float speed { get => _speed; set => _speed = value; }
    protected Rigidbody rigidBody;

    protected void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
}
