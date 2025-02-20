using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : Movement
{
    public override void UpdateAction()
    {
        rigidBody.velocity = transform.forward * speed;
    }
}
