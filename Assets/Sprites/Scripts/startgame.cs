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
            metals1.metal1 = 66f;
            woods1.wood1 = 66f;
            rubers1.rubber1 = 66f;
            foods1.food1 = 66f;
            discontent.DS = 100;
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
            Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
            unit.damage = 10;
            unit.currentHP = 100;
            unit.DamageLvl = 0;
            unit.maxHP = 100;
            unit.HpLvl = 0;
            MainMenu.startgame = 0;

        }

    }
}
