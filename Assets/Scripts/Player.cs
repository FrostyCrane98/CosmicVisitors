using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable
{
    public InputAction MoveAction;
    public InputAction ShootAction;

    public Transform Ship;
    private Rigidbody2D rb;
    private Quaternion baseRotation;
    private Quaternion RotationSpeed;
    private Quaternion MaxRotation;

    public GameObject BulletPrefab;
    public Transform BulletSpawn;

    public float MoveSpeed;
    private int Health = 10;
    private bool isMoving;
    private float input;

    private void OnEnable()
    {
        MoveAction.Enable();
        ShootAction.Enable();
        ShootAction.started += OnShoot;
        MoveAction.started += OnMoveStarted;
        MoveAction.canceled += OnMoveEnded;
    }

    private void OnDisable()
    {
        MoveAction.started -= OnMoveStarted;
        ShootAction.started -= OnShoot;
        MoveAction.canceled -= OnMoveEnded;
        MoveAction.Disable();
        ShootAction.Disable();
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
            rb.MovePosition( rb.position + direction * MoveSpeed * Time.fixedDeltaTime); 
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
        GameObject createdBullet;
        createdBullet = Instantiate(BulletPrefab,BulletSpawn.position, Quaternion.identity);
        createdBullet.layer = LayerMask.NameToLayer("PlayerBullet");
        EventManager.Instance.BulletShoot(createdBullet);
    }

    public void OnDeath()
    {
        Destroy(gameObject);
        EventManager.Instance.PlayerDeath();
    }

    public void OnDamageTaken(int _damage)
    {
        Health -= _damage;
        EventManager.Instance.PlayerHit(Health);
        if (Health <= 0)
        {
            OnDeath();
        }
    }
}
