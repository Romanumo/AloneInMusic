using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : Movement
{
    public override void UpdateAction()
    {
        this.transform.position += transform.forward * speed * Time.deltaTime;
    }
}
