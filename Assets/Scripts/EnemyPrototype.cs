using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Prototype", menuName = "Create Enemy Prototype")]
public class EnemyPrototype : ScriptableObject
{
    public int health = 1;
    public int bulletShots = 1;
    public Bullet bulletType;
    public GameObject enemyPrefab;
}
