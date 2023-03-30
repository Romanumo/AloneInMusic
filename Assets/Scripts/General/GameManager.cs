using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { Player, Win, Loss }
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private AudioSource audioObj;
    [SerializeField] private RawImage blackScreen;
    private GameState state;

    public void Awake()
    {
        if (instance == null)
            instance = this;

        BlackScreen(2f, null, true);
    }

    public void ChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Loss:
                if(this.state != state)
                    BlackScreen(2f, () => SceneManager.LoadScene(0));
                break;
            case GameState.Win:
                Debug.Log("Win!");
                break;
        }
        this.state = state;
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

    public static void BlackScreen(float time, Action postBlack, bool isInverted = false)
    {
        Action<float> update = (isInverted) ? BlackScreenFadeOut : BlackScreenFadeIn;
        TimerManager.manager.AddProgressiveTimer(postBlack, update, time);
    }

    private static void BlackScreenFadeIn(float percentage)
    {
        Color color = GameManager.instance.blackScreen.color;
        color.a = 1 - percentage;

        GameManager.instance.blackScreen.color = color;
    }

    private static void BlackScreenFadeOut(float percentage)
    {
        Color color = GameManager.instance.blackScreen.color;
        color.a = percentage;

        GameManager.instance.blackScreen.color = color;
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
