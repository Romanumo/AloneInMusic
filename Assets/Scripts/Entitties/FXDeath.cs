using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDeath : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected FXEffect onDeath;
    protected IWillDie deathOwner;

    protected void Start()
    {
        deathOwner = GetComponent<IWillDie>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (!onDeath.IsNull())
            deathOwner.OnDeath += () => PlayDeathEffect(onDeath, transform);
    }

    protected void PlayDeathEffect(FXEffect effect, Transform transform)
    {
        GameManager.CreateEffect(onDeath.particle, transform);
        GameManager.CreateAudio(effect.audio, transform.position);
    }

    protected void PlayEffect(FXEffect effect)
    {
        if (effect.particle != null)
            effect.particle.Play();
        PlaySound(effect);
    }

    protected void PlaySound(FXEffect effect)
    {
        if (effect.audio == null)
            return;

        audioSource.clip = effect.audio;
        audioSource.Play();
    }
}
