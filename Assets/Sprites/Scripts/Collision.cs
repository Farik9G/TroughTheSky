using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public GameObject player;
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
            var a = metals1.metal1;
            var b = woods1.wood1;
            var c = rubers1.rubber1;
            var d = foods1.food1;
            SaveLoadManager.BattleData.SurrogateVector3 position = this.transform.position;
            SaveLoadManager.BattleData Data = new SaveLoadManager.BattleData(a, b, c, d, position);
            SaveLoadManager.SaveButle(Data);
            SceneManager.LoadScene(2);
        }

    }
}