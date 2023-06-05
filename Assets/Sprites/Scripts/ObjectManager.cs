using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    public GameObject enemy;
    public GameObject player;
    public static int currentHp;
    public static List<string> destroyedEnemies = new List<string>();
    public static bool pirateIsDead = false;
    public static bool riotingIsDead = false;
    public static int rand = 0;
    public static float fwood;
    public static float fmetal;
    public static float frebber;
    public static float ffood;
   
  

    private void Awake()
    {
        Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
        unit.currentHP = currentHp;
        discontent.DS = currentHp;
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }


    }
    public void Update()
    {
        if (rand ==1)
        {
            SaveLoadManager.lres();
            metals1.metal1 += fmetal;
            woods1.wood1 += fwood;
            rubers1.rubber1 += frebber;
            foods1.food1 += ffood;
            rand--;
        }
    }
}
