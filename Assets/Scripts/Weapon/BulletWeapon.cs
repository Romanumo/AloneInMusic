using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : Weapon, IRanged
{
    [SerializeField] private float _attackRange;
    [SerializeField] private Bullet bullet;
    private Vector3 bulletShootPos;
    private IStateWatcher owner;
    private float _attackRangeSqr;

    public IStateWatcher watcher => owner;
    public float rangeSqr => _attackRangeSqr;

    void Start()
    {
        owner = GetComponent<IStateWatcher>();
        _attackRangeSqr = _attackRange * _attackRange;

        owner.AddState(rangeSqr, this);
    }

    public override void Attack()
    {
        bulletShootPos = transform.position + this.transform.forward * 1.5f;
        Bullet bulletInstance = Instantiate<Bullet>(bullet, bulletShootPos, transform.rotation);
        bulletInstance.AssignBullet(attack, this);
    }
}
