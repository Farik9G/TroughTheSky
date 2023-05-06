using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    //public Observer obs;
    //public  ObjectManager objectManager = ObjectManager.instance;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision detected!");
        if (other.gameObject.tag == "Enemy")
        {
            DontDestroyOnLoad(other.gameObject);
            DontDestroyOnLoad(gameObject);
            //DontDestroyOnLoad(obs);
            ObjectManager.instance.enemy = other.gameObject;
            ObjectManager.instance.player = gameObject;
            //BattleSystem.playerPrefab = gameObject;
            //BattleSystem.enemyPrefab = other.gameObject;
            
            SceneManager.LoadScene("Battle");
        }
    }
}
