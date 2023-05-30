using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EventManager.Instance.CollectionCollision();
    }
}
