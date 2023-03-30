using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : Movement
{
    public override void UpdateAction()
    {
        //this.transform.position += transform.forward * speed * Time.deltaTime;
        //rb.AddForce(transform.forward * speed * Time.deltaTime * 1000);
        rigidBody.velocity = transform.forward * speed;
    }
}
