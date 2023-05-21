using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Grid : MonoBehaviour
{   
    public Cell[,] Cells;
    public int NumberOfRows;
    public int NumberOfColumns;
    public float CellLength = 1.5f;
    public float CellHeight = 1.5f;

    private void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        Cells = new Cell[NumberOfRows, NumberOfColumns];
        for (int i = 0; i < NumberOfRows; i++) 
        {
            for (int j = 0; j < NumberOfColumns; j++)
            {
                GameObject cell = new GameObject("Cell " + j + ", " + i);
                cell.transform.parent = transform;
                Cells[i, j] = cell.AddComponent<Cell>();
                Cells[i, j].PositionInGrid = new Vector2Int(j, i);
                Cells[i, j].Height = CellHeight;
                Cells[i, j].Length = CellLength;
                Cells[i, j].transform.position = transform.position + new Vector3(CellLength*j, CellHeight* -i,0);
            }
        }
    }
}
