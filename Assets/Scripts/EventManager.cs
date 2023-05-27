using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class EventManager 
{
    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventManager();
            }
            return instance;
        }
    }
    private EventManager()
    {
    }

    public event Action<Enemy> OnEnemyDeath;

    public void EnemyDeath(Enemy _enemy)
    {
        OnEnemyDeath?.Invoke(_enemy);
    }

}
