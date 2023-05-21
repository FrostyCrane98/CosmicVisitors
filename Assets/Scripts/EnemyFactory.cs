using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour

{
    public EnemyPrototype[] enemyTypes = new EnemyPrototype[3];




    public GameObject CreateEasyEnemy()
    {
        return Instantiate(enemyTypes[0].enemyPrefab,Vector3.zero, Quaternion.identity);
    }

    public GameObject CreateMediumEnemy()
    {
        return Instantiate(enemyTypes[1].enemyPrefab,Vector3.zero, Quaternion.identity);
    }
    
    public GameObject CreateHardEnemy()
    {
        return Instantiate(enemyTypes[2].enemyPrefab,Vector3.zero,Quaternion.identity); 
    }
}
