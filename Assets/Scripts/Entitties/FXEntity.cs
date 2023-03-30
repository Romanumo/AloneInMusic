using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXEntity : FXDeath
{
    [SerializeField] private FXEffect onHealthChanged;
    [SerializeField] private BehaviourEffect[] behaviourEffects;

    private IHealth healthOwner;

    new void Start()
    {
        base.Start();
        healthOwner = GetComponent<IHealth>();

        foreach (BehaviourEffect behaviourEffect in behaviourEffects)
        {
            behaviourEffect.behaviour.OnTrigger += () => PlayEffect(behaviourEffect);
        }

        if (!onHealthChanged.IsNull())
            healthOwner.OnHealthChanged += () => PlayEffect(onHealthChanged);
    }
}

[System.Serializable]
public class FXEffect
{
    public ParticleSystem particle;
    public AudioClip audio;

    public bool IsNull()
    {
        if (particle == null && audio == null)
            return true;
        return false;
    }
}

[System.Serializable]
public class BehaviourEffect : FXEffect
{
    public SingleTimeBehavior behaviour;
}