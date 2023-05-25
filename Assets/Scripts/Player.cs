using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player : MonoBehaviour, IDamageable
{
    public InputAction moveAction;
    public InputAction shootAction;
    Rigidbody2D rb;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float moveSpeed;
    private bool isMoving;
    private float input;

    private int health = 10;
    private Enemy enemy;

    private void OnEnable()
    {
        moveAction.Enable();
        shootAction.Enable();
        shootAction.started += OnShoot;
        moveAction.started += OnMoveStarted;
        moveAction.canceled += OnMoveEnded;
    }

    private void OnDisable()
    {
        moveAction.started -= OnMoveStarted;
        shootAction.started -= OnShoot;
        moveAction.canceled -= OnMoveEnded;
        moveAction.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isMoving) 
        {
            Vector2 direction = Vector2.right * input;
            rb.MovePosition( rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }


    private void OnMoveStarted(InputAction.CallbackContext context)
    {
        isMoving = true;
        input = context.ReadValue<float>();

    }

    private void OnMoveEnded(InputAction.CallbackContext context)
    {
        isMoving = false;
        input = 0;
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        Instantiate(bulletPrefab,bulletSpawn.position, Quaternion.identity).layer = LayerMask.NameToLayer("PlayerBullet");
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }

    public void OnDamageTaken(int _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            OnDeath();
        }

    }
}
