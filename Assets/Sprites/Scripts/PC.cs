using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TG;

public class PC : MonoBehaviour
{

    [SerializeField]
    private Tilemap collisionTilemap;
    [SerializeField]
    private Tilemap groundTilemap;
    private PlayerMovement controls;
    [SerializeField] private Vector3Int currentPos;

    private void Awake()
    {
        controls = new PlayerMovement();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());

        // Найти ближайший тайл к начальной позиции игрока
        float minDistance = Mathf.Infinity;
        BoundsInt bounds = groundTilemap.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            TileBase tile = groundTilemap.GetTile(pos);
            if (tile != null)
            {
                float distance = Vector3.Distance(transform.position, groundTilemap.GetCellCenterWorld(pos));
                if (distance < minDistance)
                {
                    currentPos = pos;
                    minDistance = distance;
                }
            }
        }

        Debug.Log("Current position" + currentPos);
        transform.position = groundTilemap.GetCellCenterWorld(currentPos) - new Vector3(groundTilemap.cellSize.x / 2f, groundTilemap.cellSize.y / 4f, 0);

    }


    private void Move(Vector2 direction)
    {
        Vector3Int pT = PotentialTile(direction);
        if (groundTilemap.GetTile(pT) != null && !collisionTilemap.HasTile(pT + new Vector3Int(-2, -1, 0)))
        {
            transform.position = (groundTilemap.GetCellCenterWorld(pT) - new Vector3(groundTilemap.cellSize.x / 2f, groundTilemap.cellSize.y / 4f, 0));
            currentPos = pT;
        }
    }

    private Vector3Int PotentialTile(Vector2 direction)
    {
        if (direction.x == 1 && direction.y == 0) return new Vector3Int(0, -1, 0) + currentPos;
        else if (direction.x == -1 && direction.y == 0) return new Vector3Int(0, 1, 0) + currentPos;
        else if (direction.x == 0 && direction.y == 1) return new Vector3Int(1, 0, 0) + currentPos;
        else if (direction.x == 0 && direction.y == -1) return new Vector3Int(-1, 0, 0) + currentPos;
        return currentPos;
    }
}
