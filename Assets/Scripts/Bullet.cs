using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    public int Damage;
    public Vector2 Direction;
    private Rigidbody2D rigidBody;
    

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + Direction * BulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageableObject = (IDamageable)collider.gameObject.GetComponent(typeof(IDamageable));
        if (damageableObject != null)
        {
            damageableObject.OnDamageTaken(Damage);
        }
        Destroy(gameObject);
    }
}
