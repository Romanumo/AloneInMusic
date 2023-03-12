using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour
{
    public float rangeSqr { get; }
    public Action onInRange { get; }
    public Action onOutRange { get; }
    public void CheckTarget();
}
