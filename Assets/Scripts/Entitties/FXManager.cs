using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] private BehaviourEffect[] effects;

    void Start()
    {
        foreach (BehaviourEffect behaviourEffect in effects)
        {
            behaviourEffect.behaviour.OnTrigger += () => PlayEffect(behaviourEffect.effect);
        }
    }

    private void PlayEffect(ParticleSystem particle)
    {
        particle.Play();
    }
}

[System.Serializable]
public class BehaviourEffect
{
    public ISingleTimeBehavior behaviour;
    public ParticleSystem effect;
    //Maybe add sound here later
}