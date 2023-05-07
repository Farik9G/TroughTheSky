using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadpos : MonoBehaviour
{
   public GameObject player;
    public void Awake()
    {
        if (MainMenu.n1 == 1)
        {

            SaveLoadManager.BattleData posdata = SaveLoadManager.LoadButtle();
            player.transform.position =posdata.position;
            metals1.metal1 = posdata.metal;
            woods1.wood1 = posdata.wood;
            rubers1.rubber1 = posdata.rubber;
            foods1.food1 = posdata.food;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (ObjectManager.destroyedEnemies.Contains(enemy.name))
                {
                    Debug.Log("good");
                    enemy.SetActive(false);
                }
            }
            Debug.Log("Transform position in loadpos " + $"{posdata.position.x}, {posdata.position.y}, {posdata.position.z}");
            player.transform.position = posdata.position;
            player.transform.position = posdata.position;
            Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
            unit.damage = posdata.damage;
            unit.currentHP = ObjectManager.currentHp;
            unit.DamageLvl = posdata.damagelvl;
            unit.maxHP = posdata.Maxhp;
            unit.HpLvl = posdata.Hplvl;

            MainMenu.n1 = 10;
        }
        if (MainMenu.nn1 == 1)
        {
           SaveLoadManager.PlayerData playerData = SaveLoadManager.Load();
            metals1.metal1 = playerData.metal;
            woods1.wood1 = playerData.wood;
            rubers1.rubber1 = playerData.rubber;
            foods1.food1 = playerData.food;
            player.transform.position = playerData.position;
            ObjectManager.destroyedEnemies = playerData.destroyedEnemies;
            Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
            unit.currentHP = playerData.currenthp;
            unit.damage = playerData.damage;
            unit.maxHP = playerData.Maxhp;
            unit.DamageLvl = playerData.damagelvl;
            unit.HpLvl = playerData.Hplvl;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (ObjectManager.destroyedEnemies.Contains(enemy.name))
                {
                    Debug.Log("good");
                    enemy.SetActive(false);
                }
            }

            MainMenu.nn1 = 10;
        }

    }
}
