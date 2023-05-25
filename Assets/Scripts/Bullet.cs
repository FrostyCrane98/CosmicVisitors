using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private Vector2 direction = Vector2.up;
    public float bulletSpeed;
    public int Damage;
    Rigidbody2D rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageableObject = (IDamageable)collision.collider.gameObject.GetComponent(typeof(IDamageable));
        if (damageableObject != null)
        {
            damageableObject.OnDamageTaken(Damage);
        }
            Destroy(gameObject);
    }
}
