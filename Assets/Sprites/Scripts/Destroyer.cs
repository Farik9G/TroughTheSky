using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public static int g = 0;
    // Start is called before the first frame update
    void start()
    {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Используем найденные объекты
            foreach (GameObject enemy in enemies)
            {
                if (ObjectManager.destroyedEnemies.Contains(enemy.name))
                {
                    Debug.Log("good");
                    enemy.SetActive(false);
                }

            }
        
    }

}
