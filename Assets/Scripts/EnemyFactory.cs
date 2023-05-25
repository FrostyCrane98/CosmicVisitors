using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour

{
    public EnemyPrototype[] enemyTypes = new EnemyPrototype[3];




    public Enemy CreateEasyEnemy()
    {
        GameObject enemyGameObject = Instantiate(enemyTypes[0].enemyPrefab, Vector3.zero, Quaternion.identity);
        Enemy enemy = enemyGameObject.GetComponent<Enemy>();
        enemy.Setup(enemyTypes[0]);
        return enemy;
    }

    public Enemy CreateMediumEnemy()
    {
        GameObject enemyGameObject = Instantiate(enemyTypes[1].enemyPrefab, Vector3.zero, Quaternion.identity);
        Enemy enemy = enemyGameObject.GetComponent<Enemy>();
        enemy.Setup(enemyTypes[1]);
        return enemy;
    }
    
    public Enemy CreateHardEnemy()
    {
        GameObject enemyGameObject = Instantiate(enemyTypes[2].enemyPrefab, Vector3.zero, Quaternion.identity);
        Enemy enemy = enemyGameObject.GetComponent<Enemy>();
        enemy.Setup(enemyTypes[2]);
        return enemy;
    }
}
