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
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            _weapon?.UpdateAction();
    }

    public override void ModifyHealth(int attack, Weapon sender)
    {
        base.ModifyHealth(attack, sender);
        _healthDisplayer.UpdateBar((float)((float)health / (float)maxHealth));
    }

    public override void Die()
    {
        GameManager.instance.ChangeGameState(GameState.Loss);
    }
}

