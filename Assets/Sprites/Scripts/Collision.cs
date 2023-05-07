using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using DialogueEditor;

public class Collision : MonoBehaviour
{
    public NPCConversation PirateConversation;
    //public Observer obs;
    //public  ObjectManager objectManager = ObjectManager.instance;
    public GameObject player;
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
            var a = metals1.metal1;
            var b = woods1.wood1;
            var c = rubers1.rubber1;
            var d = foods1.food1;
            SaveLoadManager.BattleData.SurrogateVector3 position = this.transform.position;
            SaveLoadManager.BattleData Data = new SaveLoadManager.BattleData(a, b, c, d, position);
            SaveLoadManager.SaveButle(Data);
            // Debug.Log("Получилось");
            //BattleSystem.playerPrefab = gameObject;
            //BattleSystem.enemyPrefab = other.gameObject;
            // DialogueEditor.ConversationManager.OnConversationStarted(PirateBattle);
            ConversationManager.Instance.StartConversation(PirateConversation);
            Debug.Log("Получилось");




            // SceneManager.LoadScene("Battle");
        }


    }

    public void Scene()
    {
        SceneManager.LoadScene("Battle");
    }
}