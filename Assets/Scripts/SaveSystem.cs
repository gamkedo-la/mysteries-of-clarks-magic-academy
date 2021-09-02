using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveGameData.data";

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveGameData data = new SaveGameData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveGameData LoadData()
    {
        string path = Application.persistentDataPath + "/saveGameData.data";
        if (File.Exists(path))
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
