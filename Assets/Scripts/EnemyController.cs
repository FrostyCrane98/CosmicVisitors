using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyFactory EnemyFactory;
    private float easyEnemyProb = 60;
    private float mediumEnemyProb = 30;
    private int enemiesToSpawn = 30;
    private Grid grid;

    public Rigidbody2D collectionRigidBody;
    private Vector2 InitialCollectionPosition;
    private float moveSpeed = 1.5f;
    private Vector2 moveDirection = Vector2.left;
    private bool isDescending = false;
    private int numberOfEnemiesShooting = 8;
    private float attackRate = 2f;
    private float LastAttackTime = 0;
    private List<Enemy> enemies = new List<Enemy>();

    private BoxCollider2D enemyCollectionCollider;

    private void OnEnable()
    {
        EventManager.Instance.OnEnemyDeath += OnEnemyDeath;
        EventManager.Instance.OnCollectionCollision += OnCollectionCollision;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnEnemyDeath -= OnEnemyDeath;
        EventManager.Instance.OnCollectionCollision -= OnCollectionCollision;
    }

    private void Start()
    {
        grid = GetComponentInChildren<Grid>();
        SpawnEnemies();
        enemyCollectionCollider = GetComponentInChildren<BoxCollider2D>();
        enemyCollectionCollider.size = new Vector2(grid.GridLength, grid.GridHeight);
        enemyCollectionCollider.offset = new Vector2(grid.GridLength / 2 - grid.CellLength / 2, -grid.GridHeight / 2 - -grid.CellHeight / 2);
        InitialCollectionPosition = collectionRigidBody.position;
    }

    private void FixedUpdate()
    {
        if (!isDescending)
        {
            collectionRigidBody.MovePosition(collectionRigidBody.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }

        if (Time.time - LastAttackTime > attackRate)
        {
            LastAttackTime = Time.time;
            EnemiesShoot(numberOfEnemiesShooting);
        }

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

    public void EnemiesShoot(int _numberOfEnemies)
    {
        if (enemies.Count < _numberOfEnemies)
        {
            _numberOfEnemies = enemies.Count;
        }
        for (int i = 1; i <= _numberOfEnemies; i++)
        {
            int enemyShooting = Random.Range(0, enemies.Count);
            enemies[enemyShooting].Shoot();
        }
    }

    public void TakeDown()
    {
        numberOfEnemiesShooting = enemies.Count;
        attackRate = 0.2f;
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            EventManager.Instance.StageClear();
        }
        AdaptGroupCollider();
    }

    private void OnCollectionCollision()
    {
        isDescending = true;
        collectionRigidBody.transform.position = new Vector2(collectionRigidBody.position.x, collectionRigidBody.position.y - 0.5f);
        moveDirection = -moveDirection;
        isDescending = false;

        foreach (Enemy enemy in enemies)
        {
            if (enemy.transform.position.y <= -0.5)
            {
                TakeDown();
            }
        }
    }

    public void ResetEnemies()
    {
        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        enemies.Clear();
        collectionRigidBody.position = InitialCollectionPosition;
        SpawnEnemies();
        Vector2 moveDirection = Vector2.left;
        isDescending = false;
        numberOfEnemiesShooting = 8;
        attackRate = 2f;
    }
}


