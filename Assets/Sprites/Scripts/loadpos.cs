using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadpos : MonoBehaviour
{
   public GameObject player;
    public GameObject smoke1;
    public GameObject smoke2;
    public GameObject smoke3;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
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
            if (posdata.n1==false)
            {
                smoke1.SetActive(posdata.n1);
                button1.SetActive(posdata.n1);
            }
            if (posdata.n2 == false)
            {
                Destroy(smoke1);
                button2.SetActive(posdata.n2);
            }
            
            if (posdata.n3 == false)
            {
                Destroy(smoke1);
                button3.SetActive(posdata.n3);
            }
            
            Collision.arist = posdata.arist;
            Collision.scienc = posdata.scienc;
            Collision.military = posdata.military;



            MainMenu.n1 = 10;
        }
        if (MainMenu.nn1 == 1)
        {
           SaveLoadManager.PlayerData playerData = SaveLoadManager.Load();
            metals1.metal1 += playerData.metal;
            woods1.wood1 += playerData.wood;
            rubers1.rubber1 += playerData.rubber;
            foods1.food1 += playerData.food;
            player.transform.position = playerData.position;
            ObjectManager.destroyedEnemies = playerData.destroyedEnemies;
            Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
            unit.currentHP = playerData.currenthp;
            unit.damage = playerData.damage;
            unit.maxHP = playerData.Maxhp;
            unit.DamageLvl = playerData.damagelvl;
            unit.HpLvl = playerData.Hplvl;
            NewBehaviourScript.n1 = playerData.n1;
            NewBehaviourScript.n2 = playerData.n2;
            NewBehaviourScript.n3 = playerData.n3;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (ObjectManager.destroyedEnemies.Contains(enemy.name))
                {
                    Debug.Log("good");
                    enemy.SetActive(false);
                }
            }
            if (playerData.n1 == false)
            {
                Destroy(smoke1);
                button1.SetActive(playerData.n1);
            }
            if (playerData.n2 == false)
            {
                Destroy(smoke1);
                button2.SetActive(playerData.n2);
            }

            if (playerData.n3 == false)
            {
                Destroy(smoke1);
                button3.SetActive(playerData.n3);
            }
            Collision.arist = playerData.arist;
            Collision.scienc = playerData.scienc;
            Collision.military = playerData.military;

            MainMenu.nn1 = 10;
        }

    }
}
