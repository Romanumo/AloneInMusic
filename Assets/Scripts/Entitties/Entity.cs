using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Between using abstract and interface
As I see
Use abstract when needed inherited objects and they are all almost the same type
interfaces could be used in completely different objects suchh as door and Entity*/

public abstract class Entity : MonoBehaviour, IHealth, IMoveable
{
    protected int _health;
    protected Movement _movement;

    public int health { get => _health; set => _health = value; }
    public int speed { get => _movement.speed; }
    public Movement movement => _movement;

    public abstract void Die();
    public abstract void ModifyHealth();
}

public abstract class HarmfulEntity : Entity, IAttacker, IWatcher
{
    protected Weapon _weapon;

    public Weapon weapon { get => _weapon; }

    protected void Start()
    {
        _weapon = this.gameObject.GetComponent<IWeapon>();
    }
}