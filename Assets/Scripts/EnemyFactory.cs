using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour

{
    public EnemyPrototype[] EnemyTypes = new EnemyPrototype[3];




    public Enemy CreateEasyEnemy()
    {
        GameObject enemyGameObject = Instantiate(EnemyTypes[0].EnemyPrefab, Vector3.zero, Quaternion.identity);
        Enemy enemy = enemyGameObject.GetComponent<Enemy>();
        enemy.Setup(EnemyTypes[0]);
        return enemy;
    }

    public Enemy CreateMediumEnemy()
    {
        GameObject enemyGameObject = Instantiate(EnemyTypes[1].EnemyPrefab, Vector3.zero, Quaternion.identity);
        Enemy enemy = enemyGameObject.GetComponent<Enemy>();
        enemy.Setup(EnemyTypes[1]);
        return enemy;
    }
    
    public Enemy CreateHardEnemy()
    {
        GameObject enemyGameObject = Instantiate(EnemyTypes[2].EnemyPrefab, Vector3.zero, Quaternion.identity);
        Enemy enemy = enemyGameObject.GetComponent<Enemy>();
        enemy.Setup(EnemyTypes[2]);
        return enemy;
    }
}
