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
    public NPCConversation AristocratConversation2;
    public NPCConversation AristocratConversation3;

    public NPCConversation ScientistConversation;
    public NPCConversation ScientistConversation2;
    public NPCConversation ScientistConversation3;

    public NPCConversation MilitaryConversation;
    public NPCConversation MilitaryConversation2;
    public NPCConversation MilitaryConversation3;

    public NPCConversation MilitaryPirateConversation;
    public NPCConversation EndGame;
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
            var n1 = NewBehaviourScript.n1;
            var n2 = NewBehaviourScript.n2;
            var n3 = NewBehaviourScript.n3;
            var artist = Collision.arist;
            var scienc = Collision.scienc;
            var military = Collision.military;
            SaveLoadManager.BattleData Data = new SaveLoadManager.BattleData(a, b, c, d, position, destroyedEnemies, damage, damagelvl, currenthp, Maxhp, hplvl,n1, n2, n3,artist, scienc, military);
            SaveLoadManager.SaveButle(Data);
            if (other.name == "Riot-D")
            {
                ConversationManager.Instance.StartConversation(MilitaryPirateConversation);
                ObjectManager.riotingIsDead = true;
            }
            else
            {
                ConversationManager.Instance.StartConversation(PirateConversation);
                ObjectManager.pirateIsDead = true;
            }

        }

        if (other.gameObject.tag == "Aristocrat")

        {
            if (arist == 1)
            {
                arist++;
                ConversationManager.Instance.StartConversation(AristocratConversation);
            }
            else if (arist == 2) 
            {
                if (ObjectManager.pirateIsDead) arist++;
                ConversationManager.Instance.StartConversation(AristocratConversation2);
                ConversationManager.Instance.SetBool("Пиздеж", ObjectManager.pirateIsDead);
            }
            else
            {
                ConversationManager.Instance.StartConversation(AristocratConversation3);
            }

        }

        if (other.gameObject.tag == "Scientist")
        {
            if (scienc == 1)
            {
                scienc++;
                ConversationManager.Instance.StartConversation(ScientistConversation);
            }
            else if(scienc == 2)
            {
                if (rubers1.rubber1 >= 100) scienc++;
                ConversationManager.Instance.StartConversation(ScientistConversation2);
                ConversationManager.Instance.SetBool("Пиздеж", rubers1.rubber1 >= 100);
            }
            else
            {
                ConversationManager.Instance.StartConversation(ScientistConversation3);
            }
        }

        if (other.gameObject.tag == "Military")
        {
            if (military == 1)
            {
                ConversationManager.Instance.StartConversation(MilitaryConversation);
                military++;
            }
            else if (military == 2)
            {
                if (ObjectManager.riotingIsDead) military++;
                ConversationManager.Instance.StartConversation(MilitaryConversation2);
                ConversationManager.Instance.SetBool("Пиздеж", ObjectManager.riotingIsDead);
            }
            else { ConversationManager.Instance.StartConversation(MilitaryConversation3); }

        }

        if (other.gameObject.name == "Factory")
        {
            ConversationManager.Instance.StartConversation(EndGame);
        }

    }
    public void Scene()
    {
        SceneManager.LoadScene("Battle");
    }
}