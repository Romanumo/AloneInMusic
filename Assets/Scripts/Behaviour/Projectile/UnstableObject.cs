using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableObject : MonoBehaviour
{
    [SerializeField] private float averageBounce = 7500f;
    private Rigidbody rigidBody;
    private ConstantForce force;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        force = GetComponent<ConstantForce>();

        AssignRandomForce();
    }

    private void AssignRandomForce()
    {
        Random.InitState(System.DateTime.UtcNow.Millisecond);
        force.force = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        force.torque = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }

    void OnCollisionEnter(Collision collision)
    {
        Random.InitState(System.DateTime.UtcNow.Millisecond);
        rigidBody.AddForce(collision.contacts[0].normal * averageBounce * Random.Range(0.5f, 1.5f));
    }
}
