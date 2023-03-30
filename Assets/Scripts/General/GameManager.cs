using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Player, Win, Loss }
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private AudioSource audioObj;

    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Loss:
                Debug.Log("Game Over!");
                break;
            case GameState.Win:
                Debug.Log("Win!");
                break;
        }
    }

    public static RangedState GetPrioritizedState(float distanceSqr, List<RangedState> states)
    {
        RangedState lastRangedState = new RangedState(distanceSqr, null);
        foreach (RangedState state in states)
        {
            bool isWithin = state.Check(distanceSqr);
            bool isMorePrioritized = (state.rangeSqr < lastRangedState.rangeSqr || lastRangedState.behaviour == null);
            if (isWithin && isMorePrioritized)
                lastRangedState = state;
        }
        return lastRangedState;
    }

    public static void CreateEffect(ParticleSystem effect, Transform effectTransfrom)
    {
        if (effect == null)
            return;

        GameObject effectObj = Instantiate(effect.gameObject, effectTransfrom.position, effectTransfrom.rotation);
        TimerManager.manager.AddTimer(() => Destroy(effectObj), 5f);
    }

    public static void CreateEffect(ParticleSystem effect, Vector3 effectPos)
    {
        if (effect == null)
            return;

        GameObject effectObj = Instantiate(effect.gameObject, effectPos, Quaternion.identity);
        TimerManager.manager.AddTimer(() => Destroy(effectObj), 5f);
    }

    public static void CreateAudio(AudioClip sound, Vector3 effectPos)
    {
        if (sound == null)
            return;

        AudioSource audio = Instantiate<AudioSource>(instance.audioObj, effectPos, Quaternion.identity);
        audio.clip = sound;
        audio.Play();
        TimerManager.manager.AddTimer(() => Destroy(audio.gameObject), 3f);
    }
}
