using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public int InitialHealth;
    public int Health;
    public Vector2Int PositionInGrid;
    public GameObject BulletPrefab;



    public void OnDamageTaken(int _damage)
    {
        Health -= _damage ;
        if (Health <= 0)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject);
        EventManager.Instance.EnemyDeath(this);
    }

    public void Setup(EnemyPrototype _prototype)
    {
        InitialHealth = _prototype.Health;
        Health = _prototype.Health;
    }

    public void Shoot()
    {
        GameObject createdBullet;
        createdBullet = Instantiate(BulletPrefab, new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity);
        createdBullet.layer = LayerMask.NameToLayer("EnemyBullet");
        EventManager.Instance.BulletShoot(createdBullet);
    }
}
