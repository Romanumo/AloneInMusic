using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Between using abstract and interface
As I see
Use abstract when needed inherited objects and they are all almost the same type
interfaces could be used in completely different objects suchh as door and Entity*/

public enum State { Idle, Moving }
public abstract class Entity : MonoBehaviour, IHealth, IMoveable
{
    [SerializeField] protected int _health;
    protected Movement _movement;
    protected State state;

    public int health { get => _health; set => _health = value; }
    public int speed { get => _movement.speed; }
    public Movement movement => _movement;

    protected void Start()
    {
        state = State.Idle;
        _movement = GetComponent<Movement>();
    }

    protected void Update()
    {
        _movement.Move();
    }

    public abstract void Die();
    public abstract void ModifyHealth();
}