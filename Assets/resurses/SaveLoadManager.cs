using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public  class SaveLoadManager :MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public float metal;
        public float wood;
        public float rubber;
        public float food;

        public PlayerData(float metal, float wood, float rubber, float food)
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
    public void s1()
    {
        var a = metals1.metal1;
        var b = woods1.wood1;
        var c = rubers1.rubber1;
        var d = foods1.food1;
        // Сохранить данные игрока
        PlayerData playerData = new PlayerData(a, b, c, d);
        SaveLoadManager.Save(playerData);

    }
    public static void l1()
    {
        PlayerData playerData = SaveLoadManager.Load();
        metals1.metal1 = playerData.metal;
        woods1.wood1 = playerData.wood;
        rubers1.rubber1 = playerData.rubber;
        foods1.food1 = playerData.food;
        
    }
}