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
            player.transform.position = new Vector3(-7.92f, 4.78f, 0f);
            metals1.metal1 = 20f;
            woods1.wood1 = 20f;
            rubers1.rubber1 = 20f;
            foods1.food1 = 20f;
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
            unit.damage = 25;
            unit.currentHP = 100;
            unit.DamageLvl = 0;
            unit.maxHP = 100;
            unit.HpLvl = 0;
            MainMenu.startgame = 10;


        }

    }
}
