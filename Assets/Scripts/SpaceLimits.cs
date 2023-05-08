using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLimits : MonoBehaviour
{
    private Camera mainCamera;
    private float halfCameraHeight;
    private float halfCameraWidth;
    private EdgeCollider2D ec;

    private void Awake()
    {
        mainCamera = Camera.main;
        halfCameraHeight = mainCamera.orthographicSize;
        halfCameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
        ec = GetComponent<EdgeCollider2D>();

        Vector2[] points =
        {
            new Vector2(-halfCameraWidth, halfCameraHeight),
            new Vector2(halfCameraWidth, halfCameraHeight),
            new Vector2(halfCameraWidth, -halfCameraHeight),
            new Vector2(-halfCameraWidth, -halfCameraHeight),
            new Vector2(-halfCameraWidth, halfCameraHeight),
        };

        ec.points = points;
    }
}
