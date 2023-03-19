using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourCombiner : Behaviour
{
    [SerializeField] private Behaviour[] behaviours;

    public override void UpdateAction()
    {
        foreach (Behaviour behaviour in behaviours)
        {
            behaviour.UpdateAction();
        }
    }
}
