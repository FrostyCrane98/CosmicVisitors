using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyFactory EnemyFactory;
    private float easyEnemyProb = 60;
    private float mediumEnemyProb = 30;
    private int enemiesToSpawn = 30;
    private Grid grid;

    private List<Enemy> enemies = new List<Enemy>();

    private BoxCollider2D enemyCollectionCollider;


    private void Start()
    {
        grid = GetComponentInChildren<Grid>();
        SpawnEnemies();
        enemyCollectionCollider = GetComponentInChildren<BoxCollider2D>();
        enemyCollectionCollider.size = new Vector2(grid.GridLength, grid.GridHeight);
        enemyCollectionCollider.offset = new Vector2(grid.GridLength/2 - grid.CellLength/2, -grid.GridHeight/2 - -grid.CellHeight/2);
    }

    private void SpawnEnemies()
    {
        int getEnemy;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            getEnemy = Random.Range(1, 101);
            Enemy enemy = null;
            if (getEnemy <= easyEnemyProb)
            {
                enemy = EnemyFactory.CreateEasyEnemy();
                enemies.Add(enemy);
            }
            else if (getEnemy <= easyEnemyProb + mediumEnemyProb)
            {
                enemy = EnemyFactory.CreateMediumEnemy();
                enemies.Add(enemy);
            }
            else
            {
                enemy = EnemyFactory.CreateHardEnemy();
                enemies.Add(enemy);
            }
            enemy.transform.SetParent(transform.GetChild(0));
        }

        List<Cell> positions = new List<Cell>();

        foreach (Cell cell in grid.Cells)
        {
            positions.Add(cell);
        }

        foreach (Enemy enemy in enemies)
        {
            
            Cell cell = positions[Random.Range(0, positions.Count)];
            enemy.transform.position = cell.Position;
            positions.Remove(cell);
        }


    }
}
