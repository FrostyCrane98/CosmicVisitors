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
    public GameObject CellPrefab;

    public float GridLength;
    public float GridHeight;

    private void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        GameObject Grid = new GameObject("SpawnGrid");
        Grid.transform.SetParent(transform.parent);
        Cells = new Cell[NumberOfRows, NumberOfColumns];
        for (int i = 0; i < NumberOfRows; i++) 
        {
            for (int j = 0; j < NumberOfColumns; j++)
            {
                GameObject newCell = Instantiate(CellPrefab, Grid.transform);
                newCell.name = ("Cell " + j + ", " + i);
                Cells[i, j] = newCell.GetComponent<Cell>();
                Cells[i, j].PositionInGrid = new Vector2Int(j, i);
                Cells[i, j].Height = CellHeight;
                Cells[i, j].Length = CellLength;
                Cells[i, j].transform.position = transform.position + new Vector3(CellLength*j, CellHeight* -i,0);
            }
        }
        GridLength = CellLength * NumberOfColumns;
        GridHeight = CellHeight * NumberOfRows;
    }
}
