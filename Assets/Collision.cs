using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField] private Observer observer;

    void OnCollisionEnter2D(Collision2D other)
    {
        Observer.SaveObjects(gameObject, other.gameObject);
        Debug.Log("Collision detected!");
        if (other.gameObject.tag == "Enemy")
        {
            DontDestroyOnLoad(other.gameObject);
            DontDestroyOnLoad(gameObject);
            BattleSystem.playerPrefab = gameObject;
            BattleSystem.enemyPrefab = other.gameObject;
            SceneManager.LoadScene("Battle");
        }
    }
}
