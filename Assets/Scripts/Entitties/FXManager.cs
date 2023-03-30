using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    [SerializeField] private BehaviourEffect[] behaviourEffects;
    [SerializeField] private FXEffect onHealthChanged;
    [SerializeField] private FXEffect onDeath;
    [SerializeField] private AudioSource audioSource;

    private Entity owner;

    void Start()
    {
        owner = GetComponent<Entity>();
        if(audioSource == null)
            audioSource = GetComponent<AudioSource>();
        foreach (BehaviourEffect behaviourEffect in behaviourEffects)
        {
            behaviourEffect.behaviour.OnTrigger += () => PlayEffect(behaviourEffect);
        }

        if (!onDeath.IsNull())
            owner.OnDeath += () => PlayEffect(onDeath, transform);

        if (!onHealthChanged.IsNull())
            owner.OnHealthChanged += () => PlayEffect(onHealthChanged);
    }

    private void PlayEffect(FXEffect effect, Transform transform)
    {
        CreateEffect(onDeath.particle, transform);
        PlaySound(effect);
    }

    private void PlayEffect(FXEffect effect)
    {
        if(effect.particle != null)
            effect.particle.Play();
        PlaySound(effect);
    }

    private void PlaySound(FXEffect effect)
    {
        if (effect.audio == null)
            return;

        audioSource.clip = effect.audio;
        audioSource.Play();
    }

    #region StaticVoid
    public static void CreateEffect(ParticleSystem effect, Transform effectTransfrom)
    {
        GameObject effectObj = Instantiate(effect.gameObject, effectTransfrom.position, effectTransfrom.rotation);
        TimerManager.manager.AddTimer(() => Destroy(effectObj), 5f);
    }

    public static void CreateEffect(ParticleSystem effect, Vector3 effectPos)
    {
        GameObject effectObj = Instantiate(effect.gameObject, effectPos, Quaternion.identity);
        TimerManager.manager.AddTimer(() => Destroy(effectObj), 5f);
    } 
    #endregion
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
    //Maybe add sound here later
}