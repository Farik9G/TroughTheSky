using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Используем найденные объекты
        foreach (GameObject enemy in enemies)
        {
            if (ObjectManager.destroyedEnemies.Contains(enemy.name))
            {
                Debug.Log("good");
                Destroy(enemy);
            }
        }
    }

}
