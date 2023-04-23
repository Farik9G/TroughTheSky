using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestGrid : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] BoundsInt area;
    [SerializeField] List<Vector3Int> tileArrayWithoutNull = new List<Vector3Int>();
    [SerializeField] private List<TileTest> worldTiles = new List<TileTest>();

    void Start()
    {
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            var temp = tilemap.GetTile(position);
            
            if (temp != null)
                if( !tileArrayWithoutNull.Contains(position))
                    tileArrayWithoutNull.Add(position);
        }

        foreach (var position in tileArrayWithoutNull)
        {
            TileTest worldTile = new TileTest();

            worldTile.SetupHex(position, tilemap.GetCellCenterWorld(position), GetNeighbours(position));

            worldTiles.Add(worldTile);
        }
    }

    private List<Vector3> GetNeighbours(Vector3Int position) 
    {
        List<Vector3Int> neighbours = new List<Vector3Int>();
        int x = 0;
        int y = 0;
        var newPosition = position + new Vector3Int(x, y + 1, 0);
        if (tileArrayWithoutNull.Contains(newPosition))
        {
            neighbours.Add(newPosition);
        }
        newPosition = position + new Vector3Int(x, y - 1, 0);
        if (tileArrayWithoutNull.Contains(newPosition))
        {
            neighbours.Add(newPosition);
        }
        newPosition = position + new Vector3Int(x-1, y, 0);
        if (tileArrayWithoutNull.Contains(newPosition))
        {
            neighbours.Add(newPosition);
        }
        newPosition = position + new Vector3Int(x+1, y, 0);
        if (tileArrayWithoutNull.Contains(newPosition))
        {
            neighbours.Add(newPosition);
        }

        List<Vector3> worldPositions = new List<Vector3>();

        foreach (var _position in neighbours)
        {
            worldPositions.Add(tilemap.GetCellCenterWorld(_position));
        }

        return worldPositions;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
