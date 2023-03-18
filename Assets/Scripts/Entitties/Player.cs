using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private BarDisplayer _healthDisplayer;
    Weapon _weapon;

    private new void Awake()
    {
        base.Awake();
        _weapon = GetComponent<Weapon>();
        onHealthChanged += UpdateHealthBar;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            _weapon?.UpdateAction();
    }

    public void UpdateHealthBar()
    {
        _healthDisplayer.UpdateBar((float)(health / (float)maxHealth));
    }

    public override void Die()
    {
        GameManager.instance.ChangeGameState(GameState.Loss);
    }
}

