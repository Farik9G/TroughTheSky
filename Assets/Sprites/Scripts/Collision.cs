using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    //public Observer obs;
    //public  ObjectManager objectManager = ObjectManager.instance;
    public NPCConversation PirateConversation;
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
            Debug.Log("transform position in collision" + transform.position);
            SaveLoadManager.BattleData.SurrogateVector3 position = this.transform.position;
            SaveLoadManager.BattleData Data = new SaveLoadManager.BattleData(a, b, c, d, position);
            SaveLoadManager.SaveButle(Data);
            ConversationManager.Instance.StartConversation(PirateConversation);
            //BattleSystem.playerPrefab = gameObject;
            //BattleSystem.enemyPrefab = other.gameObject;





            //SceneManager.LoadScene("Battle");
        }

        
    }
    public void Scene()
    {
        SceneManager.LoadScene("Battle");
    }
}