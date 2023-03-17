using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] private BehaviourEffect[] effects;
    [SerializeField] private ParticleSystem onHealthChanged;
    [SerializeField] private ParticleSystem onDeath;

    private Entity owner;

    void Start()
    {
        owner = GetComponent<Entity>();
        foreach (BehaviourEffect behaviourEffect in effects)
        {
            behaviourEffect.behaviour.OnTrigger += () => PlayEffect(behaviourEffect.effect);
        }

        if (onDeath != null)
            owner.OnDeath += () => CreateEffect(onDeath, transform);

        if (onHealthChanged != null)
            owner.OnHealthChanged += () => PlayEffect(onHealthChanged);
    }

    private void PlayEffect(ParticleSystem particle)
    {
        particle.Play();
    }

    public static void CreateEffect(ParticleSystem effect, Transform effectTransfrom)
    {
        GameObject effectObj = Instantiate(effect.gameObject, effectTransfrom);
        TimerManager.manager.AddTimer(() => Destroy(effectObj), 5f);
    }
}

[System.Serializable]
public class BehaviourEffect
{
    public SingleTimeBehavior behaviour;
    public ParticleSystem effect;
    //Maybe add sound here later
}