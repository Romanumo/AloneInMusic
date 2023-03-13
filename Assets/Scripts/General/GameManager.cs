using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Player, Win, Loss }
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private Entity _enemiesTarget;

    public Entity enemiesTarget { get => _enemiesTarget; }

    private GameState state;

    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ChangeGameState(GameState state)
    {
        this.state = state;
        if (state == GameState.Loss)
            Debug.Log("GameOver");
    }
}
