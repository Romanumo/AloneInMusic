using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Movement movement;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        movement.UpdateAction();   
    }
}
