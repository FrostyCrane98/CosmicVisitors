using JetBrains.Annotations;
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

    Rigidbody2D collectionRigidBody;
    private float MoveSpeed = 3f;
    private Vector2 MoveDirection = Vector2.left;
    private bool isDescending = false;

    private List<Enemy> enemies = new List<Enemy>();

    private BoxCollider2D enemyCollectionCollider;

    private void OnEnable()
    {
        EventManager.Instance.OnEnemyDeath += OnEnemyDeath;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnEnemyDeath -= OnEnemyDeath;
    }

    private void Start()
    {
        grid = GetComponentInChildren<Grid>();
        SpawnEnemies();
        enemyCollectionCollider = GetComponentInChildren<BoxCollider2D>();
        enemyCollectionCollider.size = new Vector2(grid.GridLength, grid.GridHeight);
        enemyCollectionCollider.offset = new Vector2(grid.GridLength/2 - grid.CellLength/2, -grid.GridHeight/2 - -grid.CellHeight/2);
        collectionRigidBody = GetComponentInChildren<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isDescending)
        {
            collectionRigidBody.MovePosition(collectionRigidBody.position + MoveDirection * MoveSpeed * Time.fixedDeltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");
        isDescending = true;
        Descend();
        MoveDirection = -MoveDirection;
        isDescending = true;       
    }

    private void Descend()
    {
        collectionRigidBody.MovePosition(collectionRigidBody.position + Vector2.down * MoveSpeed * Time.fixedDeltaTime);
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
            enemy.PositionInGrid = cell.PositionInGrid;
            positions.Remove(cell);
        }
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        enemies.Remove(enemy);
        AdaptGroupCollider();
    }


    private void AdaptGroupCollider()
    {
        int MinXValue = int.MaxValue;
        int MaxXValue = int.MinValue;
        int MinYValue = int.MaxValue;
        int MaxYValue = int.MinValue;

        foreach (Enemy enemy in enemies)
        {
            if (enemy.PositionInGrid.x < MinXValue)
            {
                MinXValue = enemy.PositionInGrid.x;
            }
            if (enemy.PositionInGrid.x > MaxXValue)
            {
                MaxXValue = enemy.PositionInGrid.x;
            }
            if (enemy.PositionInGrid.y < MinYValue)
            {
                MinYValue = enemy.PositionInGrid.y;
            }
            if (enemy.PositionInGrid.y > MaxYValue)
            {
                MaxYValue = enemy.PositionInGrid.y;
            }
        }

        enemyCollectionCollider.size = new Vector2((float)(MaxXValue + 1 - MinXValue) * grid.CellLength, (float)(MaxYValue + 1 - MinYValue) * grid.CellHeight);
        enemyCollectionCollider.offset = new Vector2((enemyCollectionCollider.size.x - grid.CellLength) / 2, (float)-(enemyCollectionCollider.size.y - grid.CellHeight) / 2);
        if (MinXValue != 0)
        {
            enemyCollectionCollider.offset = new Vector2(enemyCollectionCollider.offset.x + grid.CellLength * MinXValue, enemyCollectionCollider.offset.y);
        }
    }
}
