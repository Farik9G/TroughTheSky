using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startgame : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Update()
    {
        if (MainMenu.startgame == 1)
        {
            player.transform.position = new Vector3(-3.824f, -3.216f, 1.09f);
            metals1.metal1 = 0f;
            woods1.wood1 = 66f;
            rubers1.rubber1 = 0f;
            foods1.food1 = 0f;
            ObjectManager.destroyedEnemies = new List<string>();
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (!ObjectManager.destroyedEnemies.Contains(enemy.name))
                {
                    Debug.Log("good");
                    enemy.SetActive(true);
                }
            }
            MainMenu.startgame = 0;

        }

    }
}
