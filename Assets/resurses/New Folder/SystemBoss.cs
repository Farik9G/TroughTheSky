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
    public GameObject vrag1;
    public GameObject vrag2;
    public GameObject vrag3;
    public GameObject vrag4;
    public GameObject vrag5;
    public static GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    public static List<string> names;
    public static bool b = true;
    // Start is called before the first frame update
    void Start()
    {

    }

        // Update is called once per frame
    void Update()
    {
        if (n==1)
        {
            foreach (GameObject enemy in enemies)
            {
                if (names.Contains(enemy.name))
                {
                    enemy.SetActive(false);
                }
            }
            n = 100;
        }
    }
    
}
