using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Player, Win, Loss }
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public Entity enemiesTarget { get => _enemiesTarget; }

    [SerializeField] private Entity _enemiesTarget;
    private GameState state;

    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ChangeGameState(GameState state)
    {
        this.state = state;
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
}
