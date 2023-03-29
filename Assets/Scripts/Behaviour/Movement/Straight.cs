using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : Movement
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void UpdateAction()
    {
        //this.transform.position += transform.forward * speed * Time.deltaTime;
        //rb.AddForce(transform.forward * speed * Time.deltaTime * 1000);
        rb.velocity = transform.forward * speed * Time.deltaTime * 250f;
        
    }
}
