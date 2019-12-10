using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static Dictionary<string, float> staticleaderboard;
    public static void save(GameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.killercube";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SaveData load()
    {
        string path = Application.persistentDataPath + "/player.killercube";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData savedata = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return (savedata);
        }
        else
        {
            Debug.LogError("AHHHH");
            return null;
        }
    }
}
