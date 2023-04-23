﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public  class SaveLoadManager :MonoBehaviour
{

    public  GameObject player;
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
        public bool boss;

        public PlayerData(float metal, float wood, float rubber, float food , SurrogateVector3 position,bool boss)
        {
            this.metal = metal;
            this.wood = wood;
            this.rubber = rubber;
            this.food = food;
            this.position = position;
            this.boss = boss;
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
        

        public BattleData(float metal, float wood, float rubber, float food, SurrogateVector3 position)
        {
            this.metal = metal;
            this.wood = wood;
            this.rubber = rubber;
            this.food = food;
            this.position = position;
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
    public static void SaveButle(BattleData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player1_data.dat";
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
        string path = Application.persistentDataPath + "/player1_data.dat";
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
    public void s1()
    {
        var a = metals1.metal1;
        var b = woods1.wood1;
        var c = rubers1.rubber1;
        var d = foods1.food1;
        var boss = SystemBoss.b;
        SaveLoadManager.PlayerData.SurrogateVector3 position = player.transform.position;
        // Сохранить данные игрока
        PlayerData playerData = new PlayerData(a, b, c, d, position, boss);
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
        SystemBoss.b = playerData.boss;
    }
    public static void lres()
    {
        PlayerData playerData = SaveLoadManager.Load();
        metals1.metal1 = playerData.metal;
        woods1.wood1 = playerData.wood;
        rubers1.rubber1 = playerData.rubber;
        foods1.food1 = playerData.food;
    }
}