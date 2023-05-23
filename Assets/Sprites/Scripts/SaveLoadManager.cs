using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public  class SaveLoadManager :MonoBehaviour
{

    public GameObject player;
    public static GameObject PlayerLoad;
    
    [System.Serializable]
    public class PlayerData
    {
        [System.Serializable]
        public struct SurrogateVector3
        {

            public float x, y, z;

            public SurrogateVector3(float rX, float rY, float rZ)
            {
                x = rX;
                y = rY;
                z = rZ;
            }

            public static implicit operator Vector3(SurrogateVector3 rValue)
            {
                return new Vector3(rValue.x, rValue.y, rValue.z);
            }

            public static implicit operator SurrogateVector3(Vector3 rValue)
            {
                return new SurrogateVector3(rValue.x, rValue.y, rValue.z);
            }
        }

        public float metal;
        public float wood;
        public float rubber;
        public float food;
        public SurrogateVector3 position;
        public List<string> destroyedEnemies;
        public int damage;
        public int damagelvl;
        public int currenthp;
        public int Maxhp;
        public int Hplvl;
        public bool n1;
        public bool n2;
        public bool n3;
        public int arist = 1;
        public int scienc = 1;
        public int military = 1;

        public PlayerData(float metal, float wood, float rubber, float food , SurrogateVector3 position, List<string> destroyedEnemies, int damage, int damagelvl, int currenthp, int Maxhp, int Hplvl, bool n1, bool  n2, bool n3,int arist, int scienc, int military)
        {
            this.metal = metal;
            this.wood = wood;
            this.rubber = rubber;
            this.food = food;
            this.position = position;
            this.destroyedEnemies = destroyedEnemies;
            this.damage = damage;
            this.damagelvl = damagelvl;
            this.currenthp = currenthp;
            this.Maxhp = Maxhp;
            this.Hplvl = Hplvl;
            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
            this.arist = arist;
            this.scienc = scienc;
            this.military = military;
        }
    }
    [System.Serializable]
    public class BattleData
    {
        [System.Serializable]
        public struct SurrogateVector3
        {

            public float x, y, z;

            public SurrogateVector3(float rX, float rY, float rZ)
            {
                x = rX;
                y = rY;
                z = rZ;
            }

            public static implicit operator Vector3(SurrogateVector3 rValue)
            {
                return new Vector3(rValue.x, rValue.y, rValue.z);
            }

            public static implicit operator SurrogateVector3(Vector3 rValue)
            {
                return new SurrogateVector3(rValue.x, rValue.y, rValue.z);
            }
        }

        public float metal;
        public float wood;
        public float rubber;
        public float food;
        public SurrogateVector3 position;
        public List<string> destroyedEnemies;
        public int damage;
        public int damagelvl;
        public int currenthp;
        public int Maxhp;
        public int Hplvl;
        public bool n1;
        public bool n2;
        public bool n3;
        public  int arist = 1;
        public  int scienc = 1;
        public  int military = 1;



        public BattleData(float metal, float wood, float rubber, float food, SurrogateVector3 position, List<string> destroyedEnemies, int damage, int damagelvl, int currenthp, int Maxhp, int Hplvl, bool n1, bool n2, bool n3, int arist, int scienc, int military)
        {
            this.metal = metal;
            this.wood = wood;
            this.rubber = rubber;
            this.food = food;
            this.position = position;
            this.destroyedEnemies = destroyedEnemies;
            this.damage = damage;
            this.damagelvl = damagelvl;
            this.currenthp = currenthp;
            this.Maxhp = Maxhp;
            this.Hplvl = Hplvl;
            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
            this.arist = arist;
            this.scienc = scienc;
            this.military = military;

        }
    }
    [System.Serializable]
    public class ResData
    {
        public float metal;
        public float wood;
        public float rubber;
        public float food;
        public ResData(float metal, float wood, float rubber, float food)
        {
            this.metal = metal;
            this.wood = wood;
            this.rubber = rubber;
            this.food = food;
        }


    }
        public static void Save(PlayerData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player_data.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveRes(ResData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerRes_data.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveButle(BattleData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Battle_data.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/player_data.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static BattleData LoadButtle()
    {
        string path = Application.persistentDataPath + "/Battle_data.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            BattleData data = formatter.Deserialize(stream) as BattleData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static ResData LoadRes()
    {
        string path = Application.persistentDataPath + "/playerRes_data.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ResData data = formatter.Deserialize(stream) as ResData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
        public void s1()
    {
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
        SaveLoadManager.PlayerData.SurrogateVector3 position = player.transform.position;
        var n1 = NewBehaviourScript.n1;
        var n2 = NewBehaviourScript.n2;
        var n3 = NewBehaviourScript.n3;
        var artist = Collision.arist;
        var scienc = Collision.scienc;
        var military = Collision.military;
        // Сохранить данные игрока
        PlayerData playerData = new PlayerData(a, b, c, d, position, destroyedEnemies, damage,damagelvl,currenthp,Maxhp,hplvl,n1,n2,n3,artist, scienc, military);

        SaveLoadManager.Save(playerData);


    }
    public  void l1()
    {
        PlayerData playerData = SaveLoadManager.Load();
        metals1.metal1 = playerData.metal;
        woods1.wood1 = playerData.wood;
        rubers1.rubber1 = playerData.rubber;
        foods1.food1 = playerData.food;
        player.transform.position = playerData.position;
        ObjectManager.destroyedEnemies = playerData.destroyedEnemies;
        Unit unit = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Unit>();
        unit.currentHP = playerData.currenthp;
        unit.damage = playerData.damage;
        unit.maxHP = playerData.Maxhp;
        unit.DamageLvl = playerData.damagelvl;
        unit.HpLvl = playerData.Hplvl;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (ObjectManager.destroyedEnemies.Contains(enemy.name))
            {
                Debug.Log("good");
                enemy.SetActive(false);
            }
        }

        MainMenu.nn1 = 1;
    }
    public static void lres()
    {
        ResData playerData = SaveLoadManager.LoadRes();
         metals1.metal1 = playerData.metal;
        woods1.wood1 = playerData.wood;
        rubers1.rubber1 = playerData.rubber;
        foods1.food1 = playerData.food;
    }
    public static void saveres()
    {
        var a = metals1.metal1;
        var b = woods1.wood1;
        var c = rubers1.rubber1;
        var d = foods1.food1;
        Debug.Log(a.ToString());
        ResData player = new ResData(a, b, c, d);
        SaveLoadManager.SaveRes(player);

    }

}