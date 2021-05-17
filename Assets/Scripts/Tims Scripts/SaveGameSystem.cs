using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveGameSystem 
{
    public static void SaveGame(GameManager gm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.george"; //any filename ending is acceptable :>
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveGameData data = new SaveGameData(gm);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveGameData LoadData ()
    {
        string path = Application.persistentDataPath + "/player.george";
        if(File.Exists(path))//wenn der File auf dem Pfad existiert
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveGameData data = formatter.Deserialize(stream) as SaveGameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
