using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TileTest
{
    [SerializeField] public Vector3Int _positionInGrid = new Vector3Int(0,0,0);
    [SerializeField] public Vector3 _position = new Vector3(0,0,0);
    [SerializeField] public List<Vector3Int> _neighbours = new List<Vector3Int> ();

    public void SetupTile(Vector3Int positionInGrid, Vector3 position, List<Vector3Int> neighbours)
    {
        _positionInGrid = positionInGrid;
        _position = position;
        _neighbours.AddRange(neighbours);
    }
}
