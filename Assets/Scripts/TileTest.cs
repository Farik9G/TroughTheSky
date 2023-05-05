using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TileTest
{
    [SerializeField] private Vector3Int _positionInGrid = new Vector3Int(0,0,0);
    [SerializeField] private Vector3 _position = new Vector3(0,0,0);
    [SerializeField] private List<Vector3> _neighbours = new List<Vector3> ();

    public void SetupTile(Vector3Int positionInGrid, Vector3 position, List<Vector3> neighbours)
    {
        _positionInGrid = positionInGrid;
        _position = position;
        _neighbours.AddRange(neighbours);
    }
}
