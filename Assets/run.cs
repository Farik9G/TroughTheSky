using UnityEngine;
using UnityEngine.Tilemaps;

public class run : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector3Int currentCell;

    private void Start()
    {
        currentCell = tilemap.WorldToCell(transform.position);
    }

    private void Update()
    {
        Vector3Int cell = currentCell;
        if (Input.GetKeyDown(KeyCode.W))
        {
            cell += new Vector3Int(0, 1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            cell += new Vector3Int(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            cell += new Vector3Int(0, -1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            cell += new Vector3Int(1, 0, 0);
        }
        if (tilemap.HasTile(cell))
        {
            transform.position = tilemap.GetCellCenterWorld(cell);
            currentCell = cell;
        }
    }
}