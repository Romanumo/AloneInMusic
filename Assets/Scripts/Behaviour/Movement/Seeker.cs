using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Movement
{
    [SerializeField] private float rotationSpeed;
    private Transform target;

    private void Start()
    {
        target = GetComponent<ITargeted>().target;
    }

    public override void UpdateAction()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion toTargetQuaternion = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, toTargetQuaternion, rotationSpeed * Time.deltaTime);

        this.transform.position += transform.forward * speed * Time.deltaTime;
    }
}
