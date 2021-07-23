using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static int Coins, LevelAt;

    static SaveSystem()
    {
        LoadPlayer();
    }
    public static void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        Debug.Log("File created");
        
        PlayerData data = new PlayerData
        {
            coins = Coins,
            levelAt = LevelAt
        };
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void LoadPlayer()
    {
       String path = Application.persistentDataPath + "/player.fun";
       
       if (!File.Exists(path))
       {
          Debug.Log("Save file not found in " + path);
           return;
       }
       Debug.Log(path);
       BinaryFormatter formatter = new BinaryFormatter();
       FileStream stream = new FileStream(path, FileMode.Open);
       PlayerData data = (PlayerData)formatter.Deserialize(stream);
       stream.Close();
       
       Coins = data.coins;
       LevelAt = data.levelAt;
    }
}
