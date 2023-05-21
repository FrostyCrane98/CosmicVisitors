using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyFactory EnemyFactory;
    private float easyEnemyProb = 60;
    private float mediumEnemyProb = 30;
    private int enemiesToSpawn = 30;

    private List<GameObject> enemies = new List<GameObject>();

    public void SpawnEnemies()
    {
        float getEnemy;
        Vector3 previousPosition = new Vector3(8, 0, 3);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            getEnemy = Random.Range(1, 101);
            if (getEnemy <= easyEnemyProb)
            {
                enemies.Add(EnemyFactory.CreateEasyEnemy());
            }
            else if (getEnemy <= easyEnemyProb + mediumEnemyProb)
            {
                enemies.Add(EnemyFactory.CreateMediumEnemy());
            }
            else
            {
                enemies.Add(EnemyFactory.CreateHardEnemy());
            }
        }
    }
}
