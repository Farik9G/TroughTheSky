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

    private void Awake()
    {
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
}
