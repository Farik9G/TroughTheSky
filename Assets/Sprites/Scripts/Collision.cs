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
    public NPCConversation AristocratConversation;
    public NPCConversation ScientistConversation;
    public NPCConversation MilitaryConversation;
    public GameObject player;
    public static int arist = 1;
    public static int scienc = 1;
    public static int military = 1;
    void OnTriggerEnter2D(Collider2D other)
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
            Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
            var currenthp = unit.currentHP;
            var damage = unit.damage;
            var Maxhp = unit.maxHP;
            var hplvl = unit.HpLvl;
            var damagelvl = unit.DamageLvl;
            var destroyedEnemies = ObjectManager.destroyedEnemies;
            Debug.Log("transform position in collision" + transform.position);
            SaveLoadManager.BattleData.SurrogateVector3 position = this.transform.position;
            SaveLoadManager.BattleData Data = new SaveLoadManager.BattleData(a, b, c, d, position, destroyedEnemies, damage, damagelvl, currenthp, Maxhp, hplvl);
            SaveLoadManager.SaveButle(Data);
            ConversationManager.Instance.StartConversation(PirateConversation);
        }

        if (other.gameObject.tag == "Aristocrat")
            
        {
            if (arist==1)
            {
                ConversationManager.Instance.StartConversation(AristocratConversation);
            }
            else
            {

            }
            
        }

        if (other.gameObject.tag == "Scientist")
        {
            if (scienc == 1)
            {
                ConversationManager.Instance.StartConversation(ScientistConversation);
            }
            else
            {

            }
        }

        if (other.gameObject.tag == "Military")
        {
            if (military == 1)
            {
                ConversationManager.Instance.StartConversation(MilitaryConversation);
            }
            else
            {

            }
            
        }

    }
    public void Scene()
    {
        SceneManager.LoadScene("Battle");
    }
}