using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public int InitialHealth;
    public int Health;
    public Vector2Int PositionInGrid;



    public void OnDamageTaken(int _damage)
    {
        Health -= _damage ;
        if (Health <= 0)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject);
        EventManager.Instance.EnemyDeath(this);
    }

    public void Setup(EnemyPrototype _prototype)
    {
        InitialHealth = _prototype.health;
        Health = _prototype.health;
    }
}
