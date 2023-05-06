using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    static public GameObject Player { get; private set; }
    static public GameObject Enemy { get; private set; }

    static public void SaveObjects(GameObject playerObject, GameObject enemyObject)
    {
        Player = playerObject;
        Enemy = enemyObject;
        Debug.Log("Objects saved");
    }
}
