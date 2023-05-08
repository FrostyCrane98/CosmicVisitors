using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction shootAction;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float moveSpeed;
    private bool isMoving;
    private float input;

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

    private void Update()
    {
        if (isMoving) 
        {
            Vector2 direction = Vector2.right * input;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
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
        Instantiate(bulletPrefab,bulletSpawn.position, Quaternion.identity);
    }
}
