using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Prototype", menuName = "Create Enemy Prototype")]
public class EnemyPrototype : ScriptableObject
{
    public int Health = 1;
    public int MoveSpeed = 50;
    public Bullet BulletType;
    public GameObject Enemyprefab;
}
