using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;
using System.Linq;

public class SystemBoss : MonoBehaviour
{
    public static int n = 0;
    public GameObject player;
    public GameObject vrag;
    public static bool b = true;
    //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    //List<string> names = new List<string>() { "123" };
    //public string[] ns = new string[] { };
    //Start is called before the first frame update
    //void Start()
    //{
    //    foreach (GameObject enemy in enemies)
    //    {
    //        ns.Contains(enemy.name);
    //        names.Contains(enemy.name);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (n == 1)
        {
            vrag.SetActive(b);
            SaveLoadManager.BattleData L = SaveLoadManager.LoadButtle();
            metals1.metal1 = L.metal + 100;
            woods1.wood1 = L.wood + 100;
            rubers1.rubber1 = L.rubber + 100;
            foods1.food1 = L.food + 100;
            player.transform.position = L.position;
            n = 100;
        }
        if ((player.transform.position == vrag.transform.position) && (n != 1) && (n != 100))
        {
            var a = metals1.metal1;
            var b = woods1.wood1;
            var c = rubers1.rubber1;
            var d = foods1.food1;
            SaveLoadManager.BattleData.SurrogateVector3 position = player.transform.position;
            SaveLoadManager.BattleData s = new SaveLoadManager.BattleData(a, b, c, d, position);
            SaveLoadManager.SaveButle(s);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
