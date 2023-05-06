using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision detected!");
        if (other.gameObject.tag == "Enemy")
        {
            DontDestroyOnLoad(other.gameObject);
            DontDestroyOnLoad(gameObject);
            ObjectManager.instance.enemy = other.gameObject;
            ObjectManager.instance.player = gameObject;
            BattleSystem.playerPrefab = gameObject;
            BattleSystem.enemyPrefab = other.gameObject;
            SceneManager.LoadScene(2);
        }

    }
}
