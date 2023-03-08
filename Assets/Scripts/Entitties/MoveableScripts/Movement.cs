using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    protected int _speed;
    public int speed { get => _speed; }
}
