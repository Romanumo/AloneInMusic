using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerMovement : Movement
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool isYRotationAllowed;
    private Transform target;

    private void Start()
    {
        target = GetComponent<ITargeted>().target;
    }

    public override void UpdateAction()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        if(!isYRotationAllowed)
            direction.y = 0;
        Quaternion toTargetQuaternion = Quaternion.LookRotation(direction);
        rigidBody.rotation = Quaternion.Slerp(transform.rotation, toTargetQuaternion, rotationSpeed * Time.deltaTime * 20f);

        float gravity = rigidBody.velocity.y;
        rigidBody.velocity = transform.forward * speed;
        rigidBody.velocity += new Vector3(0, gravity, 0);
    }
}
