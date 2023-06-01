using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public float Length = 1.5f;
    public float Height = 1.5f;
    public Vector2Int PositionInGrid;
    public Vector2 Position
    { get { return transform.position; } }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(Position.x - Length / 2, Position.y - Height / 2), new Vector2(Position.x + Length / 2, Position.y - Height / 2));
        Gizmos.DrawLine(new Vector2(Position.x + Length / 2, Position.y - Height / 2), new Vector2(Position.x + Length / 2, Position.y + Height / 2));
        Gizmos.DrawLine(new Vector2(Position.x + Length / 2, Position.y + Height / 2), new Vector2(Position.x - Length / 2, Position.y + Height / 2));
        Gizmos.DrawLine(new Vector2(Position.x - Length / 2, Position.y + Height / 2), new Vector2(Position.x - Length / 2, Position.y - Height / 2));

    }
}
