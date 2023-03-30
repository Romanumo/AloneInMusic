using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private BarDisplayer _healthDisplayer;
    private PlayerMovement movement;
    Weapon _weapon;

    private new void Awake()
    {
        base.Awake();
        movement = GetComponent<PlayerMovement>();
        _weapon = GetComponent<Weapon>();
        onHealthChanged += UpdateHealthBar;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            _weapon?.UpdateAction();
    }

    public void Knockback(Vector3 knockBack)
    {
        movement.ReceiveKnockBack(knockBack);
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

