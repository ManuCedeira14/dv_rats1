using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerDecorator :IPlayerDecorator
{
    protected PlayerModel _player;

    public PlayerDecorator(PlayerModel player)
    {
        _player = player;
    }

    public virtual void TakeDamage(float amount)
    {
        _player.TakeDamage(amount);
    }
}
