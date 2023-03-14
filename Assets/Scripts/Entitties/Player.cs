using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    Weapon weapon;
    private void Start()
    {
        weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            weapon.UpdateAction();
    }

    public override void Die()
    {
        GameManager.instance.ChangeGameState(GameState.Loss);
    }
}

